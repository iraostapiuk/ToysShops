using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Abstract
{
    public interface ITbPersonDal
    {
        List<TbPerson> GetAll();
        TbPerson GetPersonById(int id);

        TbPerson Insert(TbPerson person);
        TbPerson Update(TbPerson person);
        void Delete(int id);

    }
}
