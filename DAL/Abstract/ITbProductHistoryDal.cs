using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Abstract
{
    public interface ITbProductHistoryDal
    {
        List<TbProductHistory> GetAll();
        TbProductHistory GetProductHistoryById(int id);

        TbProductHistory Insert(TbProductHistory history);
        TbProductHistory Update(TbProductHistory history);
        void Delete(int id);
    }
}
