using DAL.Concreate;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass]
    public class TbProductHistoryTest
    {
        [TestMethod]
        public void GetAllProductHistories()
        {
            var options = new DbContextOptionsBuilder<ImdbContext>()
                .UseSqlServer("Data Source=LAPTOP-BPDBP75F;Initial Catalog=programming;Integrated Security=True;TrustServerCertificate=True;Encrypt=False")
                .Options;

            using (var context = new ImdbContext(options))
            {
                var productHistoryDal = new TbProductHistoryDal(context);
                List<TbProductHistory> productHistories = productHistoryDal.GetAll();
                // Перевірка, чи кількість отриманих записів відповідає очікуваному значенню
                Assert.AreEqual(0, productHistories.Count);
            }
        }

        [TestMethod]
        public void DeleteProductHistory()
        {
            var options = new DbContextOptionsBuilder<ImdbContext>()
                .UseSqlServer("Data Source=LAPTOP-BPDBP75F;Initial Catalog=programming;Integrated Security=True;TrustServerCertificate=True;Encrypt=False")
                .Options;

            using (var context = new ImdbContext(options))
            {
                var productHistoryDal = new TbProductHistoryDal(context);
                TbProductHistory newProductHistory = new TbProductHistory();

                TbProductHistory createdProductHistory = productHistoryDal.Insert(newProductHistory);
                int productHistoryId = createdProductHistory.HistoryId;

                productHistoryDal.Delete(productHistoryId);

                TbProductHistory deletedProductHistory = productHistoryDal.GetProductHistoryById(productHistoryId);
                Assert.IsNull(deletedProductHistory);
            }
        }

        [TestMethod]
        public void GetProductHistoryById()
        {
            var options = new DbContextOptionsBuilder<ImdbContext>()
                .UseSqlServer("Data Source=LAPTOP-BPDBP75F;Initial Catalog=programming;Integrated Security=True;TrustServerCertificate=True;Encrypt=False")
                .Options;

            using (var context = new ImdbContext(options))
            {
                var productHistoryDal = new TbProductHistoryDal(context);
                TbProductHistory newProductHistory = new TbProductHistory();

                TbProductHistory createdProductHistory = productHistoryDal.Insert(newProductHistory);
                int productHistoryId = createdProductHistory.HistoryId;

                TbProductHistory retrievedProductHistory = productHistoryDal.GetProductHistoryById(productHistoryId);
                Assert.IsNotNull(retrievedProductHistory);
                Assert.AreEqual(productHistoryId, retrievedProductHistory.HistoryId);
            }
        }

        [TestMethod]
        public void InsertProductHistory()
        {
            var options = new DbContextOptionsBuilder<ImdbContext>()
                .UseSqlServer("Data Source=LAPTOP-BPDBP75F;Initial Catalog=programming;Integrated Security=True;TrustServerCertificate=True;Encrypt=False")
                .Options;

            using (var context = new ImdbContext(options))
            {
                var productHistoryDal = new TbProductHistoryDal(context);
                TbProductHistory newProductHistory = new TbProductHistory();

                TbProductHistory insertedProductHistory = productHistoryDal.Insert(newProductHistory);
                Assert.IsNotNull(insertedProductHistory);
                Assert.AreEqual(newProductHistory.HistoryId, insertedProductHistory.HistoryId);
            }
        }

        [TestMethod]
        public void UpdateProductHistory()
        {
            var options = new DbContextOptionsBuilder<ImdbContext>()
                .UseSqlServer("Data Source=LAPTOP-BPDBP75F;Initial Catalog=programming;Integrated Security=True;TrustServerCertificate=True;Encrypt=False")
                .Options;

            using (var context = new ImdbContext(options))
            {
                var productHistoryDal = new TbProductHistoryDal(context);

                TbProductHistory newProductHistory = new TbProductHistory
                {
                    OrderId = 1,
                    OperationDate = DateTime.Now,
                    ProductQuantity = 10
                };

                TbProductHistory insertedProductHistory = productHistoryDal.Insert(newProductHistory);
                int productHistoryId = insertedProductHistory.HistoryId;

                TbProductHistory updatedProductHistory = new TbProductHistory
                {
                    HistoryId = productHistoryId,
                    OrderId = 2,
                    OperationDate = DateTime.Now,
                    ProductQuantity = 20
                };

                TbProductHistory result = productHistoryDal.Update(updatedProductHistory);
                Assert.IsNotNull(result);
                Assert.AreEqual(productHistoryId, result.HistoryId);
                Assert.AreEqual(updatedProductHistory.OrderId, result.OrderId);
                Assert.AreEqual(updatedProductHistory.OperationDate, result.OperationDate);
                Assert.AreEqual(updatedProductHistory.ProductQuantity, result.ProductQuantity);
            }
        }

    }
}
