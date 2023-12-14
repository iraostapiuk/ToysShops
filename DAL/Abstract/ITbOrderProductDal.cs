using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Abstract
{
    public interface ITbOrderProductDal
    {
        List<TbOrderProduct> GetAll();
        TbOrderProduct GetCountById(int id, int id2);
        TbOrderProduct Insert(TbOrderProduct orderProduct);
        TbOrderProduct Update(TbOrderProduct orderProduct);
        void Delete(int id, int id2);
    }
}
