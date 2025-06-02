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

namespace TestDEMNet.Views.Pages.Managers
{
    /// <summary>
    /// Логика взаимодействия для ListPartnersPage.xaml
    /// </summary>
    public partial class ListPartnersPage : Page
    {
        private DataGrid dataGrid = new DataGrid();

        public ListPartnersPage()
        {
            InitializeComponent();
            MainWindow.Root.SetBackButton();
        }

        /*
         * public int Id { get; set; }
        public string? Type { get; set; }
        public string? CompanyName { get; set; }
        public string? Address { get; set; }
        public string? Inn { get; set; }
        public string? DirectorName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public int Rating { get; set; }
        public User User { get; set; }
        */

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            dataGrid = new DataGrid();
            
            DataGridTextColumn idCol = new DataGridTextColumn()
            {
                Header = "ИД",
                Binding = new Binding("Id")
            };
            DataGridTextColumn typeCol = new DataGridTextColumn()
            {
                Header = "Тип",
                Binding = new Binding("Type")
            };
            DataGridTextColumn companyNameCol = new DataGridTextColumn()
            {
                Header = "Компания",
                Binding = new Binding("CompanyName")
            };
            DataGridTextColumn addressCol = new DataGridTextColumn()
            {
                Header = "Адресс",
                Binding = new Binding("Address")
            };
            DataGridTextColumn userCol = new DataGridTextColumn()
            {
                Header = "ИД пользователя",
                Binding = new Binding("UserId")
            };

            dataGrid.IsReadOnly = true;
            dataGrid.AutoGenerateColumns = false;

            dataGrid.Columns.Add(idCol);
            dataGrid.Columns.Add(typeCol);
            dataGrid.Columns.Add(companyNameCol);
            dataGrid.Columns.Add(addressCol);
            dataGrid.Columns.Add(userCol);

            DataPanel.Children.Add(dataGrid);

            updateDataGrid();

            UsersCmbBx.ItemsSource = ApplicationContext.Instance.Users.ToList();

            UsersCmbBx.SelectedItem = ApplicationContext.Instance.Users.First();
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            // Новое окошко с полями для заполнения
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            Partner selectedPartner = dataGrid.SelectedItem as Partner;

            if (selectedPartner != null)
            {
                // Новый page под edit

                UserCmbBox.ItemSource = ApplicationContext.Instance.Users.ToList();
                UserCmbBox.SelectedItem = selectedPartner.User;

                MessageBox.Show($"{selectedPartner.Type} {selectedPartner.CompanyName}");
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Partner selectedPartner = dataGrid.SelectedItem as Partner;

            ApplicationContext.Instance.Partners.Remove(selectedPartner);
            ApplicationContext.Instance.SaveChanges();

            updateDataGrid();
        }

        private void updateDataGrid()
        {
            dataGrid.ItemsSource = ApplicationContext.Instance.Partners.ToList();
        }
    }
}
