using System.Runtime.CompilerServices;
using System.Text;
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
using TestDEMNet.Enums;
using TestDEMNet.Views.Pages;

namespace TestDEMNet.Views.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow Root { get; set; }
        public static Page CurrentPage { get => (Page) CurrentFrame.Content; set => SetCurrentPage(value); }
        private static Frame CurrentFrame { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            Root = this;
            CurrentFrame = MainFrame;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CurrentPage = new AuthPage();

            BackBtnsStack.Children.Clear();
        }

        public void SetBackButton()
        {
            BackBtnsStack.Children.Clear();

            Button button = CreateButtonForBack("Назад");

            button.Click += Back_Click;

            BackBtnsStack.Children.Add(button);
        }

        public void SetLogoutButton()
        {
            BackBtnsStack.Children.Clear();

            Button button = CreateButtonForBack("Выйти");

            button.Click += Logout_Click;

            BackBtnsStack.Children.Add(button);
        }

        private Button CreateButtonForBack(String content)
        {
            Button button = new Button
            {
                Content = content,
                Width = 50,
                Height = 25,
                FontFamily = new FontFamily("Segou UI"),
                Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#67BA80")),
            };

            return button;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            BackBtnsStack.Children.Clear();
            SetMenuByRole(AuthPage.AuthUser.Role);
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            BackBtnsStack.Children.Clear();
            AuthPage.AuthUser = null;
            CurrentPage = new AuthPage();
        }

        public static void SetCurrentPage(Object value)
        {
            CurrentFrame.Content = value;
        }

        public static void SetMenuByRole(Role userRole)
        {
            switch (userRole)
            {
                case Enums.Role.MANAGER:
                    MainWindow.CurrentPage = new ManagerMenuPage();
                    break;
                case Enums.Role.PARTNER:
                    MainWindow.CurrentPage = new PartnerMenuPage();
                    break;

                default:
                    MessageBox.Show("Обратитесь к администратору!", "Ошибка авторизации", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
            }
        }
    }
}