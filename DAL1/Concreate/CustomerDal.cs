using DAL1.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL1.Concreate
{
    public class CustomerDal : ICustomerDal
    {
        private readonly ImdbContext _dbContext;
        public CustomerDal(ImdbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public static string Format(Customer customer)
        {
            return $"CustomerID: {customer.CustomerId}, CustomerFirstName: {customer.FirstName}, CustomerLastName: {customer.LastName}, CustomerPhone: {customer.Phone}, CustomerCityAdress{customer.AddressCity}";
        }
        public void Delete(int id)
        {
            var customer= _dbContext.Customers.Find(id);
            if (customer!= null)
            {
                _dbContext.Customers.Remove(customer);
                _dbContext.SaveChanges();
            }
        }

        public List<Customer> GetAll()
        {
            return _dbContext.Customers.ToList();
        }

        public Customer GetCustomerById(int id)
        {
            return _dbContext.Customers.Find(id);
        }

        public Customer Insert(Customer customer)
        {
            _dbContext.Customers.Add(customer);
            _dbContext.SaveChanges();
            return customer;
        }

        public Customer Update(Customer customer)
        {
            _dbContext.Entry(customer).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return customer;
        }
    }
}
