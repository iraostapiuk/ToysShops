using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Navigation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp2.UserControls;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        HomePage homePage = new HomePage();
        CustomerPage customerPage = new CustomerPage();

        public MainWindow()
        {
            InitializeComponent();
            MainDisplay.NavigationUIVisibility = NavigationUIVisibility.Hidden;
            MainDisplay.Content = homePage;
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            MainDisplay.Content = homePage;
        }

        private void CustomersButton_Click(object sender, RoutedEventArgs e)
        {
            //MainDisplay.Content = customerPage;
            CustomerPage customerPage = new CustomerPage();

            Window customerWindow = new Window
            {
                Title = "Customer Page",
                Content = customerPage,
                Width = 600,
                Height = 400,
                WindowStartupLocation = WindowStartupLocation.CenterScreen
            };

            customerWindow.ShowDialog();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            ExitProgram();
        }

        private void ExitProgram()
        {
            App.Current.Shutdown();
            Process.GetCurrentProcess().Kill();
        }
    }
}
