using DAL1.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL1.Concreate
{
    public class OrderDal : IOrderDal
    {
        private readonly ImdbContext _dbContext;
        public OrderDal(ImdbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public static string Format(Order order)
        {
            return $"OrderId: {order.OrderId}, CustomerId: {order.CustomerId}, OrderDate: {order.OrderDate}";
        }
        public void Delete(int id)
        {
            var order = _dbContext.Orders.Find(id);
            if (order != null)
            {
                _dbContext.Orders.Remove(order);
                _dbContext.SaveChanges();
            }
        }

        public List<Order> GetAll()
        {
            return _dbContext.Orders.ToList();
        }

        public Order GetOrderById(int id)
        {
            return _dbContext.Orders.Find(id);
        }

        public Order Insert(Order order)
        {
            _dbContext.Orders.Add(order);
            _dbContext.SaveChanges();
            return order;
        }

        public Order Update(Order order)
        {
            _dbContext.Entry(order).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return order;
        }
    }
}
