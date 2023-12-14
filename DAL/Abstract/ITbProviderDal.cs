using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Abstract
{
    public interface ITbProviderDal
    {
        List<TbProvider> GetAll();
        TbProvider GetProviderById(int id);

        TbProvider Insert(TbProvider provider);
        TbProvider Update(TbProvider provider);
        void Delete(int id);
    }
}
