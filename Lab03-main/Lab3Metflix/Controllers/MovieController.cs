using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.Model;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using Lab3Metflix.Models;
using System.IO;

namespace Lab3Metflix.Controllers
{
    public class MovieController : Controller
    {
        string domain = AppDomain.CurrentDomain.BaseDirectory;
        RegionEndpoint Region = RegionEndpoint.USEast1;

        private IAmazonDynamoDB _dynamoDBClient;
        private IAmazonS3 _s3Client;

        public MovieController(IAmazonDynamoDB _dynamoDBClient, IAmazonS3 _s3Client)
        {
            this._dynamoDBClient = _dynamoDBClient;
            this._s3Client = _s3Client;
            CreateTable();
        }

        [HttpGet]
        public IActionResult MovieList(string email)
        {
            MovieList movieList = new MovieList()
            {
                Users = GetUsers(email).Result,
                Movies = GetMovies().Result
            };
            return View("MovieList", movieList);
        }

        [HttpPost]
        public IActionResult MovieList()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateMovie(MovieBucket movieBucket)
        {
            string domain = AppDomain.CurrentDomain.BaseDirectory;

            if (ModelState.IsValid)
            {

                var MovieVideo = new MemoryStream();
                movieBucket.MovieVideo.CopyTo(MovieVideo);
                var MovieImage = new MemoryStream();
                movieBucket.MovieImage.CopyTo(MovieImage);

                var result = UploadFile(movieBucket.SelectedBucket,
                    movieBucket.Movie.MovieTitle,
                    MovieVideo,
                    MovieImage
                  ).Result;
            }
            return MovieList(movieBucket.Email);

        }
        [HttpGet]
        public IActionResult CreateMovie(string email)
        {
            return View(new MovieBucket() { Buckets = GetBuckets(), Email = email });
        }


        [HttpGet]
        public IActionResult MovieDetail(string email, string movieId)
        {
           
            return View(new UsersMovie()
            {
                Users = GetUsers(email).Result,
                Movie = GetMovie(movieId).Result
            });
        }

        [HttpGet]
        public ActionResult DownloadMovie(string MovieId)
        {
          
            string domain = AppDomain.CurrentDomain.BaseDirectory;
            Movie movie = GetMovie(MovieId).Result;
            return PhysicalFile(domain + movie.MovieId + movie.MovieVideo.GetType(), "MovieVideo/avi", movie.MovieTitle);
        }

        [HttpGet]
        public IActionResult CreateComment(string email, string movieId)
        {
           
            return View(new MoviesRating()
            {
                Movie = GetMovie(movieId).Result,
                Users = GetUsers(email).Result,
                Rating = new Rating()
            });
        }

        [HttpPost]
        public IActionResult CreateComment(string email, string movieId, string comment, int RateNum)
        {
          
            AddComment(email, movieId, comment, RateNum);
            return RedirectToAction("MovieDetail", new {email,movieId });
        }

        public async Task<Users> GetUsers(string email)
        {
            DynamoDBContext Context = new DynamoDBContext(_dynamoDBClient);

            return await Context.LoadAsync<Users>(email);
        }

        public Task<Movie> GetMovie(string MovieId)
        {
            DynamoDBContext Context = new DynamoDBContext(_dynamoDBClient);

            return Context.LoadAsync<Movie>(MovieId);

        }

        public async Task<List<Movie>> GetMovies()
        {
            DynamoDBContext Context = new DynamoDBContext(_dynamoDBClient);

            var conditions = new List<ScanCondition>();
            List<Movie> movies = await Context.ScanAsync<Movie>(conditions).GetRemainingAsync();
            foreach (Movie movie in movies)
            {
                Task task1 = _s3Client.DownloadToFilePathAsync(
                    movie.MovieImage.BucketName,
                    movie.MovieImage.Key, domain,
                    new Dictionary<string, object>(),
                    default);
            }
            return movies;
        }

        public List<String> GetBuckets()
        {
            List<String> buckets = new List<string>();
            ListBucketsResponse response = _s3Client.ListBucketsAsync().Result;
            foreach (S3Bucket bucket in response.Buckets)
            {
                buckets.Add(bucket.BucketName);
            }
            return buckets;
        }

        public async Task<Movie> UploadFile(string BucketName, string MovieTitle, Stream MovieVideoPath, Stream MovieImagePath)
        {
            DynamoDBContext Context = new DynamoDBContext(_dynamoDBClient);

            Movie movie = new Movie();
            movie.MovieId = Guid.NewGuid().ToString();
            movie.MovieTitle = MovieTitle;
            movie.MovieImage = S3Link.Create(Context, BucketName, movie.MovieId + "1.jpg", Region);
            movie.MovieVideo = S3Link.Create(Context, BucketName, movie.MovieId + "2.avi", Region);

            var fileTransferUtility = new TransferUtility(_s3Client);
            var MovieImage = new TransferUtilityUploadRequest()
            {
                CannedACL = S3CannedACL.PublicRead,
                BucketName = BucketName,
                Key = movie.MovieId + "1.jpg",
                InputStream = MovieImagePath
            };

            var MovieVideo = new TransferUtilityUploadRequest()
            {
                CannedACL = S3CannedACL.PublicRead,
                BucketName = BucketName,
                Key = movie.MovieId + "2.avi",
                InputStream = MovieVideoPath
            };
            await fileTransferUtility.UploadAsync(MovieImage);
            await fileTransferUtility.UploadAsync(MovieVideo);

            await Context.SaveAsync<Movie>(movie);
            return await GetMovie(movie.MovieId);
        }

        public async void AddComment(string email, string MovieId, string comment, int RateNum)
        {
            DynamoDBContext Context = new DynamoDBContext(_dynamoDBClient);

            Movie movie = await GetMovie(MovieId);
            movie.Ratings.Add(new Rating()
            {
                RateDate = DateTime.Now,
                Comment = comment,
                RateNum = RateNum,
                Users = await Context.LoadAsync<Users>(email)
            });

            await Context.SaveAsync<Movie>(movie);
        }
       
        public void CreateTable()
        {
            string tableName = "Users";
            Task<ListTablesResponse> table = _dynamoDBClient.ListTablesAsync();
            List<string> currentTables = table.Result.TableNames;
            bool tablesAdded = false;
            if (!currentTables.Contains(tableName))
            {
                _dynamoDBClient.CreateTableAsync(new CreateTableRequest
                {
                    TableName = tableName,
                    ProvisionedThroughput = new ProvisionedThroughput
                    {
                        ReadCapacityUnits = 3,
                        WriteCapacityUnits = 1
                    },
                    KeySchema = new List<KeySchemaElement>
                    {
                        new KeySchemaElement
                        {
                            AttributeName = "Email",
                            KeyType = KeyType.HASH
                        }
                    },
                    AttributeDefinitions = new List<AttributeDefinition>
                    {
                        new AttributeDefinition
                        {
                            AttributeName = "Email",
                            AttributeType = ScalarAttributeType.S
                        }
                    },
                });

                _dynamoDBClient.CreateTableAsync(new CreateTableRequest
                {
                    TableName = "Movie",
                    ProvisionedThroughput = new ProvisionedThroughput
                    {
                        ReadCapacityUnits = 3,
                        WriteCapacityUnits = 1
                    },
                    KeySchema = new List<KeySchemaElement>
                    {
                        new KeySchemaElement
                        {
                            AttributeName = "MovieId",
                            KeyType = KeyType.HASH
                        }
                    },
                    AttributeDefinitions = new List<AttributeDefinition>
                    {
                        new AttributeDefinition
                        {
                            AttributeName = "MovieId",
                            AttributeType = ScalarAttributeType.S
                        }
                    },
                });
                tablesAdded = true;
            }

            if (tablesAdded)
            {
                bool allActive;
                do
                {
                    allActive = true;
                    Thread.Sleep(TimeSpan.FromSeconds(5));

                    TableStatus tableStatus = GetTableStatus(tableName);
                    if (!Equals(tableStatus, TableStatus.ACTIVE))
                        allActive = false;

                } while (!allActive);
            }
        }

        private TableStatus GetTableStatus(string TableName)
        {
            try
            {
                Task<DescribeTableResponse> tableResp = _dynamoDBClient.DescribeTableAsync(new DescribeTableRequest { TableName = TableName });
                TableDescription table = tableResp.Result.Table;
                return (table == null) ? null : table.TableStatus;
            }
            catch (AmazonDynamoDBException db)
            {
                if (db.ErrorCode == "ResourceNotFoundException")
                    return string.Empty;
                throw;
            }
        }
    }
}
