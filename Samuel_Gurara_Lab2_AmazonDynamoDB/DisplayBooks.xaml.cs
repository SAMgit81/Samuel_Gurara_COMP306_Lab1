using System;
using System.Collections.Generic;
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
    /// Interaction logic for BooksView.xaml
    /// </summary>
    public partial class BooksView : Window
    {
        DBContext operations;
        Shelf bookshelf = new Shelf();
        private static string username;
        public BooksView(string user)
        {
            operations = new DBContext("UserTable");
            username = user;
            InitializeComponent();
            bookshelf = operations.getUserBookshelf(user);
            WelcomeLabel.Content = "Hello " + user;
            AddBookListButtons();
        }
        public object Children { get; private set; }
        public void AddBookListButtons()
        {
            foreach (var item in bookshelf.Books)
            {
                string[] arrayOfTests = item.Key.Split(new string[] { ",", " ", "."}, StringSplitOptions.RemoveEmptyEntries);
                string newString = String.Join("", arrayOfTests);
                Button newButtton = new Button();

                newButtton.Content = item.ToString();
                newButtton.Margin = new Thickness(0, 0, 0, 0);
                newButtton.Name = "btn";
                newButtton.Height = 70;
                newButtton.Width = 250;
                newButtton.Click += (s, e) =>
                {
                    BooksReaderView readerview = new BooksReaderView(item.Key.ToString(), item.Value, username);
                    readerview.Show();
                };
                newButtton.Background = Brushes.LightBlue;
                newButtton.BorderBrush = Brushes.Gray;
                this.grid.Children.Add(newButtton);
            }
        }
    }
}
