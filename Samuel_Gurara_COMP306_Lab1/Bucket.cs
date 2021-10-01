using Amazon;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Samuel_Gurara_COMP306_Lab1
{
    public class Bucket
    {
        public string BName { get; set; }
        public string CreationTime { get; set; }
        public override string ToString()
        {
            return $"{BName}";
        }
        public void getList()
        {
            GetBucketList();
        }
        private static async void GetBucketList()
        {
            var builder = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("AppSettings.json", optional: true, reloadOnChange: true);

            var accessKeyID = builder.Build().GetSection("AWSCredentials").GetSection("AccesskeyID").Value;
            var secretKey = builder.Build().GetSection("AWSCredentials").GetSection("Secretaccesskey").Value;

            var credentials = new BasicAWSCredentials(accessKeyID, secretKey);
            try
            {
                using (AmazonS3Client s3Client = new AmazonS3Client(credentials, RegionEndpoint.USEast1))
                {
                    ListBucketsResponse response = await s3Client.ListBucketsAsync();
                    foreach (S3Bucket bucket in response.Buckets)
                    {
                        Console.WriteLine(bucket.BucketName + " " + bucket.CreationDate.ToShortDateString());
                    }
                }
            }
            catch (AmazonS3Exception ex)
            {
                Console.WriteLine("Error encountered on server. Message:'{0}' when writing an object", ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unknown encountered on server. Message:'{0}' when writing an object", ex.Message);
            }

        }
    }
}

