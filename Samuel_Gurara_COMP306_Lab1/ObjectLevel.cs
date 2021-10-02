using System;
using Amazon;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.Extensions.Configuration;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;
using Amazon.S3.Transfer;

namespace Samuel_Gurara_COMP306_Lab1
{
    public partial class ObjectLevel : Form
    {
        string filepath = "";
        public ObjectLevel()
        {
            InitializeComponent();
            GetBucketList();
        }
        public async void GetBucketList()
        {
          //  BasicAWSCredentials credentials = config();
            try
            {
                using (AmazonS3Client s3Client = new AmazonS3Client(Config.config(), RegionEndpoint.USEast1))
                {
                    ListBucketsResponse response = await s3Client.ListBucketsAsync();
                    foreach (S3Bucket bucket in response.Buckets)
                    {
                        Console.WriteLine(bucket.BucketName + " " + bucket.CreationDate.ToShortDateString());
                    }
                    int combo_list = response.Buckets.Count;
                    if (combo_list > 0)
                    {
                        foreach (S3Bucket bucket in response.Buckets)
                        {
                            cbxBucket.Items.Add(bucket.BucketName);
                        }
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

        private void btnBackToMain_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form = new Form1();
            form.Show();
        }
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            int size = -1;
            System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();
            DialogResult dialogResult = openFileDialog.ShowDialog();
            if (dialogResult == (DialogResult)1)
            {
                filepath = openFileDialog.FileName;
                try
                {
                    string text = File.ReadAllText(filepath);
                    size = text.Length;
                    txtObj.Text = filepath;
                    txtObj.Text = Path.GetFileName(Path.GetDirectoryName(filepath));
                }
                catch (IOException)
                {

                }
            }
            Console.WriteLine(size);
            Console.WriteLine(dialogResult);
        }

        private async void combo_list()
        {
            string bucketName = (string)cbxBucket.SelectedItem;
            if (bucketName == null || bucketName.Length <= 0)
            {
                return;
            }
            //Extracted Method
           // BasicAWSCredentials credentials = config();
            try
            {
                using (AmazonS3Client s3Client = new AmazonS3Client(Config.config(), RegionEndpoint.USEast1))
                {
                    ListObjectsRequest request = new ListObjectsRequest();
                    List<Obj> datasource = new List<Obj>();
                    request.BucketName = bucketName;
                    ListObjectsResponse response = await s3Client.ListObjectsAsync(request);
                    foreach (S3Object o in response.S3Objects)
                    {
                        datasource.Add(new Obj { object_name = o.Key, object_size = o.Size });
                    }
                    DataObjectGrid.DataSource = datasource;
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
        private void cbxBucket_SelectedIndexChanged(object sender, EventArgs e)
        {
            combo_list();
        }

        private void txtObj_TextChanged(object sender, EventArgs e)
        {
            txtObj.Text = filepath;
        }

        private async void btnUpload_Click(object sender, EventArgs e)
        {
            string filepath = txtObj.Text;
            string bucketName = (string)cbxBucket.SelectedItem;
            if (filepath == null || filepath.Length <= 0) { return; }
            if (bucketName == null || bucketName.Length <= 0) { return; }
            string Key = Path.GetFileName(filepath);
            try
            {
                //Extracted Method
                using (AmazonS3Client s3Client = new AmazonS3Client(Config.config(), RegionEndpoint.USEast1))
                {
                    var fileTransferUtility = new TransferUtility(s3Client);

                    await fileTransferUtility.UploadAsync(filepath, bucketName, Key);
                    Console.WriteLine("Upload 2 completed");
                    combo_list();
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

        //Extracted Method
       /* private static BasicAWSCredentials config()
        {
            var builder = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("AppSettings.json", optional: true, reloadOnChange: true);

            var accessKeyID = builder.Build().GetSection("AWSCredentials").GetSection("AccesskeyID").Value;
            var secretKey = builder.Build().GetSection("AWSCredentials").GetSection("Secretaccesskey").Value;

            var credentials = new BasicAWSCredentials(accessKeyID, secretKey);
            return credentials;
        }*/
    }   
}
