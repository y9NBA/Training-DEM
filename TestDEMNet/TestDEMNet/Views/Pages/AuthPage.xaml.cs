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
using TestDEMNet.Context;
using TestDEMNet.Models;
using TestDEMNet.Views.Windows;

namespace TestDEMNet.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        public static User? AuthUser { get; set; } = null;

        public AuthPage()
        {
            InitializeComponent();
        }

        private void SignIn_Click(object sender, RoutedEventArgs e)
        {
            string username = Username.Text;
            string password = Password.Password;

            User? user = ApplicationContext.Instance.Users.FirstOrDefault(u => u.Username.Equals(username) && u.Password.Equals(password));

            if (user == null)
            {
                MessageBox.Show("Неверные учётные данные!", "Ошибка авторизации", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            AuthUser = user;

            MainWindow.SetMenuByRole(user.Role);
        }

        private void SignUp_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
