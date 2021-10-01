using System;
using Amazon;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.Extensions.Configuration;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;

namespace Samuel_Gurara_COMP306_Lab1
{
    public partial class CreateBucket : Form
    {
        public CreateBucket()
        {
            InitializeComponent();
            GetBucketList();
        }
       
        private async void GetBucketList()
        {
            BasicAWSCredentials credentials = config();

            try { 
            using (AmazonS3Client s3Client = new AmazonS3Client(credentials, RegionEndpoint.USEast1))
            {
                ListBucketsResponse response = await s3Client.ListBucketsAsync();
                List<Bucket> datasource = new List<Bucket>();
                foreach (S3Bucket bucket in response.Buckets)
                {
                    datasource.Add(new Bucket
                    {
                        BName = bucket.BucketName,
                        CreationTime = bucket.CreationDate.ToString()
                    });
                }
                dataCreateBucket.DataSource = datasource;
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


        private void btnBackToMain_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }

        private async void btnCreateBucket_Click(object sender, EventArgs e)
        {
            BasicAWSCredentials credentials = config();

            using (AmazonS3Client s3Client = new AmazonS3Client(credentials, RegionEndpoint.USEast1))
            {
                string bucketName = txtBucket.Text;
                if (bucketName.Length < 5)
                {
                    return;
                }
                PutBucketRequest putBucketRequest = new PutBucketRequest();
                putBucketRequest.BucketName = bucketName;
                await s3Client.PutBucketAsync(putBucketRequest);

                GetBucketList();
            }
        }

        private static BasicAWSCredentials config()
        {
            var builder = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("AppSettings.json", optional: true, reloadOnChange: true);

            var accessKeyID = builder.Build().GetSection("AWSCredentials").GetSection("AccesskeyID").Value;
            var secretKey = builder.Build().GetSection("AWSCredentials").GetSection("Secretaccesskey").Value;

            var credentials = new BasicAWSCredentials(accessKeyID, secretKey);
            return credentials;
        }

    }
}