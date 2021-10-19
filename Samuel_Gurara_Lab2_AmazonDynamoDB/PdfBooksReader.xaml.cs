using Amazon;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Samuel_Gurara_Lab2_AmazonDynamoDB
{
    /// <summary>
    /// Interaction logic for BooksReaderView.xaml
    /// </summary>
    public partial class BooksReaderView : Window
    {
        DBContext operations = new DBContext("Bookshelf");
        private static string Books;
        private static int pagenumber;
        private static string username;
        public BooksReaderView(string books, int pageNumber, string user)
        {
            username = user;
            Books = books;
            pagenumber = pageNumber;
            InitializeComponent();
            pdfViewer.IsBookmarkEnabled = true;
            viewBookReader(books, pagenumber);
        }

        public async void viewBookReader(string books, int pageNumber)
        {
            var accessKeyID = ConfigurationManager.AppSettings["accessId"];
            var secretKey = ConfigurationManager.AppSettings["secretKey"];

            var credentials = new BasicAWSCredentials(accessKeyID, secretKey);
            using (AmazonS3Client s3Client = new AmazonS3Client(credentials, RegionEndpoint.USEast1))
            {
                var request = new GetObjectRequest()
                {
                    BucketName = "userbooks",
                    Key = books
                };
                var response = await s3Client.GetObjectAsync(request);
                MemoryStream _documentStream = new MemoryStream();
                response.ResponseStream.CopyTo(_documentStream);
                pdfViewer.ItemSource = _documentStream;
                if (pageNumber != 0)
                    pdfViewer.GotoPage(pageNumber);
            }
        }

        public void btnBookmark_Click(object sender, RoutedEventArgs e)
        {
            var bookmark = pdfViewer.CurrentPage;
            operations.updateLastReadPage(username, Books, bookmark);
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            var bookmark = pdfViewer.CurrentPage;
            operations.updateLastReadPage(username, Books, bookmark);
        }
    }
}
