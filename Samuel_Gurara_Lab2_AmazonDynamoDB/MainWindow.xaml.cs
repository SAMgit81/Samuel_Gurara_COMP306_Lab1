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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Samuel_Gurara_Lab2_AmazonDynamoDB
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DBContext db = new DBContext();
        public MainWindow()
        {
            InitializeComponent();
            db.CreateTable();
            System.Threading.Thread.Sleep(7000);
            db.InsertItem("s", "sami");
            db.InsertItem("Samuel", "Samuel123");
            db.InsertItem("admin", "password");
        }


        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            var username = usernametextbox.Text;
            var password = PasswordTextBox.Password;
            if (!username.Equals("") && !password.Equals(""))
            {
                var validUser = db.ValidateUser(username, password);
                if (validUser)
                {
                    BooksView readerView = new BooksView(username);
                    readerView.Show();
                }
            }
        }
    }
}
