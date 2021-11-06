
using System.Collections.Generic;
using Amazon.DynamoDBv2.DataModel;


namespace Lab3Metflix.Models
{
    [DynamoDBTable("Movie")]
    public class Movie
    {
        [DynamoDBHashKey]
        public string MovieId { get; set; }

        public string MovieTitle { get; set; }
        
        //public DateTime MovieYear { get; set; }

        public S3Link MovieImage { get; set; }

        public S3Link MovieVideo { get; set; }

        [DynamoDBProperty(AttributeName = "Ratings")]
        public List<Rating> Ratings { get; set; } = new List<Rating>();

    }
}
