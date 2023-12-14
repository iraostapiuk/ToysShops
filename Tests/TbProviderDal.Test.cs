using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Concreate;

namespace Tests
{
    [TestClass]
    public class TbProviderDal
    {
        [TestMethod]
        public void GetAllProviders()
        {
            //var options = new DbContextOptionsBuilder<ImdbContext>()
            //    .UseSqlServer("з'єднання_з_базою_даних")
            //    .Options;

            //using (var context = new ImdbContext(options))
            //{
            //    var providerDal = new TbProviderDal(context);
            //    List<TbProvider> providers = providerDal.GetAll();
            //    Assert.AreEqual(0, providers.Count);
            //}
        }

        [TestMethod]
        public void DeleteProvider()
        {
            //var options = new DbContextOptionsBuilder<ImdbContext>()
            //    .UseSqlServer("з'єднання_з_базою_даних")
            //    .Options;

            //using (var context = new ImdbContext(options))
            //{
            //    var providerDal = new TbProviderDal(context);
            //    TbProvider newProvider = new TbProvider();

            //    TbProvider createdProvider = providerDal.Insert(newProvider);
            //    int providerId = createdProvider.ProviderId;

            //    providerDal.Delete(providerId);

            //    TbProvider deletedProvider = providerDal.GetProviderById(providerId);
            //    Assert.IsNull(deletedProvider);
            //}
        }

        [TestMethod]
        public void GetProviderById()
        {
            //var options = new DbContextOptionsBuilder<ImdbContext>()
            //    .UseSqlServer("з'єднання_з_базою_даних")
            //    .Options;

            //using (var context = new ImdbContext(options))
            //{
            //    var providerDal = new TbProviderDal(context);
            //    TbProvider newProvider = new TbProvider();

            //    TbProvider createdProvider = providerDal.Insert(newProvider);
            //    int providerId = createdProvider.ProviderId;

            //    TbProvider retrievedProvider = providerDal.GetProviderById(providerId);
            //    Assert.IsNotNull(retrievedProvider);
            //    Assert.AreEqual(providerId, retrievedProvider.ProviderId);
            //}
        }

        [TestMethod]
        public void InsertProvider()
        {
            //var options = new DbContextOptionsBuilder<ImdbContext>()
            //    .UseSqlServer("з'єднання_з_базою_даних")
            //    .Options;

            //using (var context = new ImdbContext(options))
            //{
            //    var providerDal = new TbProviderDal(context);
            //    TbProvider newProvider = new TbProvider();

            //    TbProvider insertedProvider = providerDal.Insert(newProvider);
            //    Assert.IsNotNull(insertedProvider);
            //    Assert.AreEqual(newProvider.ProviderId, insertedProvider.ProviderId);
            //}
        }

        [TestMethod]
        public void UpdateProvider()
        {
            //var options = new DbContextOptionsBuilder<ImdbContext>()
            //    .UseSqlServer("з'єднання_з_базою_даних")
            //    .Options;

            //using (var context = new ImdbContext(options))
            //{
            //    var providerDal = new TbProviderDal(context);

            //    TbProvider newProvider = new TbProvider
            //    {
            //        ProviderName = "Назва постачальника",
            //        ProviderPhone = "Телефон постачальника"
            //    };

            //    TbProvider insertedProvider = providerDal.Insert(newProvider);
            //    int providerId = insertedProvider.ProviderId;

            //    TbProvider updatedProvider = new TbProvider
            //    {
            //        ProviderId = providerId,
            //        ProviderName = "Нова назва постачальника",
            //        ProviderPhone = "Новий телефон постачальника"
            //    };

            //    TbProvider result = providerDal.Update(updatedProvider);
            //    Assert.IsNotNull(result);
            //    Assert.AreEqual(providerId, result.ProviderId);
            //    Assert.AreEqual(updatedProvider.ProviderName, result.ProviderName);
            //    Assert.AreEqual(updatedProvider.ProviderPhone, result.ProviderPhone);
            //}
        }
    }
}






        
    



