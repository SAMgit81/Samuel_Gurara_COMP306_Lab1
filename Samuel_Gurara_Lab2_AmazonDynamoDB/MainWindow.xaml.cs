using System.Windows;

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
