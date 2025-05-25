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

namespace TestDem.Pages.Buyer
{
    /// <summary>
    /// Логика взаимодействия для CatalogPage.xaml
    /// </summary>
    public partial class CatalogPage : Page
    {
        public CatalogPage()
        {
            InitializeComponent();
        }

        private void AddInOrder_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int amount = int.Parse(Amount.Text);

                Good good = (Good)Goods.SelectedItem;

                if (good == null)
                {
                    MessageBox.Show("Товар не выбран");
                    return;
                }

                if (amount <= 0 || good.amount < amount) 
                {
                    MessageBox.Show("Такого количества товара нет");
                    return;
                }

                good.amount -= amount;

                Database.Instance.Good.Add(good);

                Order order = Database.Instance.Order.FirstOrDefault(o => o.status == Status.NEW.ToString());

                if (order == null)
                {
                    order.user_id = Session.CurrentUser.id;
                    order.total_price = 0;
                    order.status = Status.NEW.ToString();

                    order = Database.Instance.Order.Add(order);
                }

                Order_Good order_Good = new Order_Good();

                order_Good.order_id = order.id;
                order_Good.good_id = good.id;
                order_Good.amount = amount;
                order_Good.price = good.price * amount;

                Database.Instance.Order_Good.Add(order_Good);

                order.total_price += order_Good.price;

                Database.Instance.Order.Add(order);
                Database.save();
            }
            catch (FormatException) 
            {
                MessageBox.Show("Неверное количество товара");
                return;
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Navigation.CurrentFrame.Navigate(new MainPage());
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Goods.ItemsSource = Database.Instance.Good.ToList();
        }
    }
}
