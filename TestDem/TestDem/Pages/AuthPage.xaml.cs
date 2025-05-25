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
using TestDem.Utils;

namespace TestDem.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        public AuthPage()
        {
            InitializeComponent();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Navigation.Root.Close();
        }

        private void SignIn_Click(object sender, RoutedEventArgs e)
        {
            User user = Database.Instance.User.FirstOrDefault(u => u.username == Login.Text && u.password == Password.Password);

            if (user != null)
            {
                Session.CurrentUser = user;

                MessageBox.Show($"Приветствуем вас, {user.username} :)", "Вход", MessageBoxButton.OK, MessageBoxImage.Information);
                Navigation.CurrentFrame.Navigate(new MainPage());
            }
            else
            {
                MessageBox.Show("Неверные учётные данные", "GG", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SignUp_Click(object sender, RoutedEventArgs e)
        {
            Navigation.CurrentFrame.Navigate(new RegisterPage());
        }
    }
}
