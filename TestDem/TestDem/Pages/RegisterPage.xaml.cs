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
    /// Логика взаимодействия для RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Page
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Navigation.CurrentFrame.Navigate(new AuthPage());
        }

        private void BuyerRegister_Click(object sender, RoutedEventArgs e)
        {
            Navigation.CurrentFrame.Navigate(new RegisterBuyerPage());
        }

        private void SellerRegister_Click(object sender, RoutedEventArgs e)
        {
            Navigation.CurrentFrame.Navigate(new RegisterSellerPage());
        }
    }
}
