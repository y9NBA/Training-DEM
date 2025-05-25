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
using TestDem.Pages.Buyer;
using TestDem.Pages.Seller;
using TestDem.Utils;

namespace TestDem.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            Session.CurrentUser = null;
            Navigation.CurrentFrame.Navigate(new AuthPage());
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Username.Content = Session.CurrentUser.username;

            if (Session.CurrentUser.role_name == Role.SELLER.ToString())
            {
                BuyerStack.Visibility = Visibility.Hidden;
            }
            else
            {
                SellerStack.Visibility = Visibility.Hidden;
            }
        }

        #region Buyer

        private void ViewCatalog_CLick(object sender, RoutedEventArgs e)
        {
            Navigation.CurrentFrame.Navigate(new CatalogPage());
        }

        private void ViewBasket_Click(object sender, RoutedEventArgs e)
        {
            Navigation.CurrentFrame.Navigate(new BasketPage());
        }

        private void ViewMyOrder_Click(object sender, RoutedEventArgs e)
        {
            Navigation.CurrentFrame.Navigate(new MyOrderPage());
        }

        #endregion


        #region Seller

        private void ViewOrder_Click(object sender, RoutedEventArgs e)
        {
            Navigation.CurrentFrame.Navigate(new OrderPage());
        }
        
        private void ViewGood_CLick(object sender, RoutedEventArgs e)
        {
            Navigation.CurrentFrame.Navigate(new GoodPage());
        }

        #endregion


        private void ViewProfile_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
