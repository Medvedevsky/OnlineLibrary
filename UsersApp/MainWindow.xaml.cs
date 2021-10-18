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
using System.Data.Entity;

namespace UsersApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ApplicationContex db;
        public MainWindow()
        {
            InitializeComponent();
            db = new ApplicationContex();
            List<User> users = db.Users.ToList();
            string str = "";
            foreach (User user in users)
                str += "Login:"+ user.Login + " | ";


            
        }

        private void signinButton_Click(object sender, RoutedEventArgs e)
        {
            string login = loginBox.Text.Trim();
            string email = emailBox.Text.Trim(' ').ToLower();
            string password = passwordBox.Password;
            string passwordAgain = againPasswordBox.Password;

            if (!(email.Contains("@") && email.Contains(".")))
            {
                emailBox.ToolTip = "Введите email";
                emailBox.Foreground = Brushes.Red;
            }
            else if(login.Length < 5)
            {
                loginBox.ToolTip = "Длина логина меньше 5 символов";
                loginBox.Foreground = Brushes.Red;
            }

            else if (password.Length < 8)
            {
                passwordBox.ToolTip = "Пароль слабый";
                passwordBox.Foreground = Brushes.Red;
            }
            else if (password != passwordAgain)
            {
                againPasswordBox.ToolTip = "Пароли не совпадают";
                againPasswordBox.Foreground = Brushes.Red;
            }



            else
            {
                loginBox.ToolTip = "";
                loginBox.Foreground = Brushes.Transparent;
                passwordBox.ToolTip = "";
                passwordBox.Foreground = Brushes.Transparent;
                againPasswordBox.ToolTip = "";
                againPasswordBox.Foreground = Brushes.Transparent;
                emailBox.ToolTip = "";
                emailBox.ToolTip = emailBox.Foreground = Brushes.Transparent;


                MessageBox.Show("Молодец! Ты зарегистрирован! :)");
                User user = new User(login, password, email);
                db.Users.Add(user);
                db.SaveChanges();
                AuthWindow authWindow = new AuthWindow();
                authWindow.Show();
                Hide();
            }
        }
    }
}
