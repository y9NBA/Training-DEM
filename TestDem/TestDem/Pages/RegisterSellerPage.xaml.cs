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
using TestDem.Pages;
using TestDem.Utils;

namespace TestDem
{
    /// <summary>
    /// Логика взаимодействия для RegisterSellerPage.xaml
    /// </summary>
    public partial class RegisterSellerPage : Page
    {
        public RegisterSellerPage()
        {
            InitializeComponent();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Navigation.CurrentFrame.GoBack();
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            string login = Login.Text;    // *
            string password = Password.Password;    // *
            string secondName = SecondName.Text;    // *
            string firstName = FirstName.Text;    // *
            string patronymic = Patronymic.Text;
            string numberPhone = NumberPhone.Text;    // *
            string email = Email.Text;
            string address = Address.Text;    // *

            if (login == string.Empty
                || password == string.Empty
                || password == string.Empty
                || secondName == string.Empty
                || firstName == string.Empty
                || numberPhone == string.Empty
                || address == string.Empty)
            {
                MessageBox.Show("Одно или несколько обязательных полей '*' не заполнены", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Stop);
                return;
            }

            User user = new User();

            user.username = login;
            user.password = password;
            user.role_name = Role.SELLER.ToString();

            User foundUser = Database.Instance.User.FirstOrDefault(u => u.username == Login.Text);

            if (foundUser != null)
            {
                MessageBox.Show("Такой логин уже занят", "Не получилось :(", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            user = Database.Instance.User.Add(user);

            Personal personal = new Personal();

            personal.second_name = secondName;
            personal.first_name = firstName;
            personal.patronymic = patronymic == string.Empty ? null : patronymic;
            personal.number_phone = numberPhone;
            personal.email = email == string.Empty ? null : email;
            personal.address = address;
            personal.user_id = user.id;

            Database.Instance.Personal.Add(personal);

            Database.save();

            Navigation.CurrentFrame.Navigate(new AuthPage());
        }
    }
}
