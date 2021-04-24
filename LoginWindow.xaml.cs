/*
Name: Soni Kunj Mayurkumar
Student ID: 991591881
Date of Submission: 25 February 2021
Topic: Midterm Exam
Guided by: Gursharan Singh Tatla
 */

using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace MTKunjSoni
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        
        //dictionary to store the collection of login names
        private Dictionary<string, Login> _logins;

        //loginwindow
        public LoginWindow()
        {

            InitializeComponent();
            _logins = new Dictionary<string, Login>();
        }

        //window loaded method
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _logins.Add("admin", new Login(1, "admin", "system"));
            _logins.Add("sonikunj", new Login(2, "sonikunj", "991591881"));
            _logins.Add("k", new Login(3, "k", "k"));

        }

        //login button to go into mainWindoe
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Password;

            Login user = null;

            if (_logins.ContainsKey(username))
            {
                user = _logins[username];
                if (user.Password == password)
                {
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Background = Brushes.Azure;
                    mainWindow.Title = "View Players";
                    mainWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                    mainWindow.Show();
                    Close();
                }
                else
                {
                    MessageBox.Show("Incorrect Login! Password incorrect!", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
            else
            {
                MessageBox.Show("Incorrect Login! Username incorrect!","Login Failed",MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }

        //cancel button to close the application
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Are you sure, you would like to quit?", "Warning",MessageBoxButton.YesNo,MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                Close();
            }
        }

    }
}
