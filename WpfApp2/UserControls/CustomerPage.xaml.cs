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
    /// <summary>
    /// Interaction logic for CustomerPage
    /// </summary>
    public partial class CustomerPage : UserControl

    {
        private Customer selectedCustomer= new Customer();
        private ObservableCollection<Customer> customers = new ObservableCollection<Customer>();
        public CustomerPage()
        {
            InitializeComponent();
            GetCustomers();
        }
        private void GetCustomers()
        {
            customers = DbServices.customerDbService.Select();
            CustomersGridView.ItemsSource = customers;

        }
        private void CustomerGridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedCustomer = (Customer)CustomersGridView.SelectedItem;
            FirstNameTextBox.Text = selectedCustomer.FirstName;
            LastNameTextBox.Text = selectedCustomer.LastName;
            AdressTextBox.Text = selectedCustomer.AddressCity;

            if (PhoneNumeric != null)
            {
                PhoneNumeric.Value = selectedCustomer.Phone;
            }
        }
        private void ReadCustomerButton_Click(object sender, RoutedEventArgs e)
        {
            GetCustomers();
        }
       
        private void UpdateSelectedCustomer()
        {
            selectedCustomer.FirstName = FirstNameTextBox.Text;
            selectedCustomer.LastName = LastNameTextBox.Text;
            selectedCustomer.AddressCity = AdressTextBox.Text;
            selectedCustomer.Phone = (int)PhoneNumeric.Value;
        }
        //This method attempts to create an employee
        private void CreateCustomerButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateSelectedCustomer();

            if (DbServices.customerDbService.Insert(selectedCustomer))
            {
                MessageBox.Show("Customer Created!");
            }
            else
            {
                MessageBox.Show("An error occured while creating your employee.");
            }
        }
        //This method attempts to update an employee
        private void UpdateCustomerButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateSelectedCustomer();

            if (DbServices.customerDbService.Update(selectedCustomer))
            {
                MessageBox.Show("Customer Updated!");
            }
            else
            {
                MessageBox.Show("An error occured while updating your employee.");
            }
        }
        //This method attempts to delete an employee
        private void DeleteCustomerButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateSelectedCustomer();

            if (DbServices.customerDbService.Delete(selectedCustomer))
            {
                MessageBox.Show("Customer Deleted!");
            }
            else
            {
                MessageBox.Show("An error occured while deleting your employee.");
            }
        }
    }
}
