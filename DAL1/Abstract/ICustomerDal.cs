using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL1.Abstract
{
    public interface ICustomerDal
    {
        List<Customer> GetAll();
        Customer GetCustomerById(int id);

        Customer Insert(Customer customer);
        Customer Update(Customer customer);
        void Delete(int id);

    }
}
