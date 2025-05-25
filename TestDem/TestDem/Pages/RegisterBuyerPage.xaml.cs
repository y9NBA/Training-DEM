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
using TestDem.Constants;
using TestDem.Utils;

namespace TestDem.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegisterBuyerPage.xaml
    /// </summary>
    public partial class RegisterBuyerPage : Page
    {
        public RegisterBuyerPage()
        {
            InitializeComponent();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Navigation.CurrentFrame.GoBack();
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            User user = new User();

            user.username = Login.Text;
            user.password = Password.Password;
            user.role_name = Role.BUYER.ToString();

            User foundUser = Database.Instance.User.FirstOrDefault(u => u.username == Login.Text);

            if (foundUser != null)
            {
                MessageBox.Show("Такой логин уже занят", "Не получилось :(", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            Database.Instance.User.Add(user);
            Database.save();

            Navigation.CurrentFrame.Navigate(new AuthPage());
        }
    }
}
