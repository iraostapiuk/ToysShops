using DAL.Abstract;
using Microsoft.Data.SqlClient;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DAL;

namespace DAL.Concreate
{
    public class TbOrderDal : ITbOrderDal
    {
        private readonly ImdbContext _dbContext;
        public TbOrderDal(ImdbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public static string Format(TbOrder order)
        {
            return $"OrderId: {order.OrderId}, PersonId: {order.PersonId}, OrderDate: {order.OrderDate}";
        }
        public void Delete(int id)
        {
            var order = _dbContext.TbOrders.Find(id);
            if (order != null)
            {
                _dbContext.TbOrders.Remove(order);
                _dbContext.SaveChanges();
            }
        }

        public List<TbOrder> GetAll()
        {
            return _dbContext.TbOrders.ToList();
        }

        public TbOrder GetOrderById(int id)
        {
            return _dbContext.TbOrders.Find(id);
        }

        public TbOrder Insert(TbOrder order)
        {
            _dbContext.TbOrders.Add(order);
            _dbContext.SaveChanges();
            return order;
        }

        public TbOrder Update(TbOrder order)
        {
            _dbContext.Entry(order).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return order;
        }
    }
}
