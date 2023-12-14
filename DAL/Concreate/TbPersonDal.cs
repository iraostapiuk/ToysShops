using DAL.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concreate
{
    public class TbPersonDal : ITbPersonDal
    {
         private readonly ImdbContext _dbContext;

        public TbPersonDal(ImdbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Delete(int id)
        {
            var person = _dbContext.TbPeople.Find(id);
            if (person != null)
            {
                _dbContext.TbPeople.Remove(person);
                _dbContext.SaveChanges();
            }
        }

        public List<TbPerson> GetAll()
        {
            return _dbContext.TbPeople.ToList(); 
        }

        public TbPerson GetPersonById(int id)
        {
            return _dbContext.TbPeople.Find(id);
        }

        public TbPerson Insert(TbPerson person)
        {
            _dbContext.TbPeople.Add(person);
            _dbContext.SaveChanges();
            return person;
        }

        public TbPerson Update(TbPerson person)
        {
            _dbContext.Entry(person).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return person;
        }
    }
}
