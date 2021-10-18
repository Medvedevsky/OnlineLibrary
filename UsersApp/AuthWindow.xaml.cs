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

namespace UsersApp
{
    /// <summary>
    /// Interaction logic for AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

        

        private void authButton_Click(object sender, RoutedEventArgs e)
        {
            string login = loginBox.Text.Trim();
            string password = passwordBox.Password;

            if (login.Length < 5)
            {
                loginBox.ToolTip = "Длина логина меньше 5 символов";
                loginBox.Foreground = Brushes.Red;
            }

            else if (password.Length < 8)
            {
                passwordBox.ToolTip = "Пароль слабый";
                passwordBox.Foreground = Brushes.Red;
            }
            else
            {
                loginBox.ToolTip = "";
                loginBox.Foreground = Brushes.Transparent;
                passwordBox.ToolTip = "";
                passwordBox.Foreground = Brushes.Transparent;

                User authUser = null;
                using (ApplicationContex db = new ApplicationContex())
                {
                    authUser = db.Users.Where(b => b.Login == login && b.Pass == password).FirstOrDefault();
                }

                if (authUser != null)
                { 
                    MessageBox.Show("Все хорошо!");
                    UserPageWindow userPageWindow = new UserPageWindow();
                    userPageWindow.Show();
                    Hide();
                }
                else
                    MessageBox.Show("Вы ввели не все хорошо!");
            }
        }

        private void reg_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Hide();
        }
    }
}
