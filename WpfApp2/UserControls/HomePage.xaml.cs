using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using WpfApp2.Models;
using WpfApp2.Services;


namespace WpfApp2.UserControls
{
    public partial class HomePage : Page
    {
        private ObservableCollection<Customer> customers = new ObservableCollection<Customer>();

        public HomePage()
        {
            InitializeComponent();
            GetCustomers();
            
        }
      
   
        private void RefreshCustomersButton_Click(object sender, RoutedEventArgs e)
        {
            GetCustomers();
        }
        
      
        private void GetCustomers()
        {
            customers = DbServices.customerDbService.Select();
            CustomersGridView.ItemsSource = customers;
        }
    }
}
