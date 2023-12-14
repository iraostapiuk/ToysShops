using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Abstract
{
    public interface ITbProductDal
    {
        List<TbProduct> GetAll();
        TbProduct GetProductById(int id);

        TbProduct Insert(TbProduct product);
        TbProduct Update(TbProduct product);
        void Delete(int id);

    }
}
