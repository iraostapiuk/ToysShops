using DAL;
using Microsoft.Identity.Client.Extensions.Msal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Abstract
{
    public interface ITbOrderDal
    {
        List<TbOrder> GetAll();
        TbOrder GetOrderById(int id);

        TbOrder Insert(TbOrder order);
        TbOrder Update(TbOrder order);  
        void Delete(int id);

    }
}


//public interface IToyDal
//{
//    List<Toy> GetAll();
//    Toy GeToyById(int id);
//    Toy Insert(Toy toy);
//    Toy Update(Toy toy);
//    void Delete(int id);

//}
//public interface IShopDal
//{
//    List<Shop> GetAll();
//    Shop GeToyById(int id);
//    Shop Insert(Shop toy);
//    Shop Update(Shop toy);
//    void Delete(int id);

//}

//public interface IStorageDal
//{
//    List<Storage> GetAll();
//    Storage GeToyById(int id);
//    Storage Insert(Storage storage);
//    Storage Update(Storage storage);
//    void Delete(int id);
//}
