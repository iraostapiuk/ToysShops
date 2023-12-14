using DAL.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concreate
{
    public class TbProviderDal : ITbProviderDal
    {
        private readonly ImdbContext _dbContext;

        public TbProviderDal(ImdbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Delete(int id)
        {
            var provider = _dbContext.TbProviders.Find(id);
            if (provider != null)
            {
                _dbContext.TbProviders.Remove(provider);
                _dbContext.SaveChanges();
            }
        }

        public List<TbProvider> GetAll()
        {
            return _dbContext.TbProviders.ToList();
        }

        public TbProvider GetProviderById(int id)
        {
            return _dbContext.TbProviders.Find(id);
        }

        public TbProvider Insert(TbProvider provider)
        {
            _dbContext.TbProviders.Add(provider);
            _dbContext.SaveChanges();
            return provider;
        }

        public TbProvider Update(TbProvider provider)
        {
            _dbContext.Entry(provider).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return provider;
        }
    }
}
