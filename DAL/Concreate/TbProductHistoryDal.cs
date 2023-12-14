using DAL.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concreate
{
    public class TbProductHistoryDal : ITbProductHistoryDal
    {
        private readonly ImdbContext _dbContext;

        public TbProductHistoryDal(ImdbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Delete(int id)
        {
            var history = _dbContext.TbProductHistories.Find(id);
            if (history != null)
            {
                _dbContext.TbProductHistories.Remove(history);
                _dbContext.SaveChanges();
            }
        }

        public List<TbProductHistory> GetAll()
        {
            return _dbContext.TbProductHistories.ToList();
        }

        public TbProductHistory GetProductHistoryById(int id)
        {
            return _dbContext.TbProductHistories.Find(id);
        }

        public TbProductHistory Insert(TbProductHistory history)
        {
            _dbContext.TbProductHistories.Add(history);
            _dbContext.SaveChanges();
            return history;
        }

        public TbProductHistory Update(TbProductHistory history)
        {
            _dbContext.Entry(history).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return history;
        }
    }
}
