using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL1.Abstract
{
    public interface IOrderDal
    {
        List<Order> GetAll();
        Order GetOrderById(int id);

        Order Insert(Order order);
        Order Update(Order order);
        void Delete(int id);

    }
}
