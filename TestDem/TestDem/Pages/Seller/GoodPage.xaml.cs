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

namespace TestDem.Pages.Seller
{
    /// <summary>
    /// Логика взаимодействия для GoodPage.xaml
    /// </summary>
    public partial class GoodPage : Page
    {
        public GoodPage()
        {
            InitializeComponent();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Navigation.CurrentFrame.Navigate(new MainPage());
        }
    }
}
