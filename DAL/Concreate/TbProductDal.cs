using DAL.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concreate
{
    public class TbProductDal : ITbProductDal
    {
        private readonly ImdbContext _dbContext;

        public TbProductDal(ImdbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Delete(int id)
        {
            var product = _dbContext.TbProducts.Find(id);
            if (product != null)
            {
                _dbContext.TbProducts.Remove(product);
                _dbContext.SaveChanges();
            }
        }

        public List<TbProduct> GetAll()
        {
            return _dbContext.TbProducts.ToList();
        }

        public TbProduct GetProductById(int id)
        {
            return _dbContext.TbProducts.Find(id);
        }

        public TbProduct Insert(TbProduct product)
        {
            _dbContext.TbProducts.Add(product);
            _dbContext.SaveChanges();
            return product;
        }

        public TbProduct Update(TbProduct product)
        {
            _dbContext.Entry(product).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return product;
        }
    }
}
