using DAL.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concreate
{
    public class TbOrderProductDal : ITbOrderProductDal
    {
        private readonly ImdbContext _dbContext;

        public TbOrderProductDal(ImdbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public static string Format(TbOrderProduct orderProduct)
        {
            return $"OrderProduct ID: {orderProduct.OrderId}, Product ID: {orderProduct.ProductId}, Count: {orderProduct.Count}";
        }
        public void Delete(int id, int id2)
        {
            var orderProduct = _dbContext.TbOrderProducts.FirstOrDefault(op => op.OrderId == id && op.ProductId == id);
            if (orderProduct != null)
            {
                _dbContext.TbOrderProducts.Remove(orderProduct);
                _dbContext.SaveChanges();
            }
        }

        public List<TbOrderProduct> GetAll()
        {
            return _dbContext.TbOrderProducts.ToList();
        }

        public TbOrderProduct GetCountById(int id, int id2)
        {
            return _dbContext.TbOrderProducts.FirstOrDefault(op => op.OrderId ==id  && op.ProductId == id);
        }

        public TbOrderProduct Insert(TbOrderProduct orderProduct)
        {
            _dbContext.TbOrderProducts.Add(orderProduct);
            _dbContext.SaveChanges();
            return orderProduct;
        }

        public TbOrderProduct Update(TbOrderProduct orderProduct)
        {
            _dbContext.Entry(orderProduct).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return orderProduct;
        }
    }
}
