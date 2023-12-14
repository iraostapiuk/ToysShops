using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApp2.Models;

namespace WpfApp2.Services
{
    class CustomerDbService: Customer
    {
        private MySqlConnection connection;


        //Constructor
        public CustomerDbService()
        {
            connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlServer"].ConnectionString);
            
        }

        //open connection to database
        private bool OpenConnection()
        {
            try
            {
                CloseConnection();
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;
                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }


        //Insert statement
        public bool Insert(Customer customer)
        {
            try
            {
                //open connection
                if (this.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand("INSERT INTO ToyShop.Customers (FirstName, LastName, AddressCity, Phone) VALUES (?firstname, ?lastname, ?adress, ?phone)", connection);
                    //Add parameters to the query. Its important to use parameters to avoid SQL injections
                    cmd.Parameters.AddWithValue("?firstname", customer.FirstName);
                    cmd.Parameters.AddWithValue("?lastname", customer.LastName);
                    cmd.Parameters.AddWithValue("?address", customer.AddressCity);
                    cmd.Parameters.AddWithValue("?phone", customer.Phone);
                    //Execute command
                    cmd.ExecuteNonQuery();
                    //close connection
                    this.CloseConnection();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }


        //Update statement
        public bool Update(Customer customer)
        {
            try
            {
                //Open connection
                if (this.OpenConnection() == true)
                {
                    //create mysql command
                    MySqlCommand cmd = new MySqlCommand("UPDATE ToyShop.Customers SET FirstName = ?firstname, LastName = ?lastname, AddressCity = ?adress, Phone = ?phone WHERE ID = ?id", connection);
                    cmd.Parameters.AddWithValue("?id", customer.CustomerId);
                    cmd.Parameters.AddWithValue("?firstname", customer.FirstName);
                    cmd.Parameters.AddWithValue("?lastname", customer.LastName);
                    cmd.Parameters.AddWithValue("?address", customer.AddressCity);
                    cmd.Parameters.AddWithValue("?phone", customer.Phone);
                    //Execute query
                    cmd.ExecuteNonQuery();
                    //close connection
                    this.CloseConnection();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }


        //Delete statement
        public bool Delete(Customer customer) //deletes the coffee from the DB
        {
            try
            {
                if (this.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM ToyShop.Customerss WHERE ID = ?id", connection);
                    cmd.Parameters.AddWithValue("?id", customer.CustomerId);
                    cmd.ExecuteNonQuery();
                    this.CloseConnection();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }


        //Select statement
        public ObservableCollection<Customer> Select() //returns a collection of all the Employees
        {
            string query = "SELECT * FROM ToyShop.Customers";
            //list of Employees
            ObservableCollection<Customer> employees = new ObservableCollection<Customer>();
            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create the data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();
                //Read the data and store them in the collection
                while (dataReader.Read())
                {
                    //creates the Employee object
                    Customer customer = new Customer();
                    //sets the Employee's properties
                    customer.CustomerId = Convert.ToInt32(dataReader["ID"]);
                    customer.FirstName = Convert.ToString(dataReader["FirstName"]);
                    customer.LastName = Convert.ToString(dataReader["LastName"]);
                    customer.AddressCity = Convert.ToString(dataReader["Address"]);
                    customer.Phone = Convert.ToInt32(dataReader["Phone"]);
                    //adds the employee to the collection
                    employees.Add(customer);
                }
                //close Data Reader
                dataReader.Close();
                //close Connection
                this.CloseConnection();
                //return the collection
                return employees;
            }
            else
            {
                return null;
            }
        }
    }
}
