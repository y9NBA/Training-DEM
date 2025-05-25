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
using TestDEMNet.Views.Pages.Managers;
using TestDEMNet.Views.Windows;

namespace TestDEMNet.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для ManagerMenuPage.xaml
    /// </summary>
    public partial class ManagerMenuPage : Page
    {
        public ManagerMenuPage()
        {
            InitializeComponent();
            MainWindow.Root.SetLogoutButton();
        }

        private void ViewPartners_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.CurrentPage = new ListPartnersPage();
        }

        private void ViewOrdersPartners_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.CurrentPage = new ListOrdersPartnersPage();
        }

        private void ViewStatHistory_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.CurrentPage = new StatHistoryPage();
        }

        private void ViewHistoryRating_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.CurrentPage = new HistoryRatingPage();
        }
    }
}
