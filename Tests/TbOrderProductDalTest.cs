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
    public class TbOrderProductDalTest
    {

        [TestMethod]
        public void GetAllOrderProducts()
        {
            var options = new DbContextOptionsBuilder<ImdbContext>()
                .UseSqlServer("Data Source=LAPTOP-BPDBP75F;Initial Catalog=programming;Integrated Security=True;TrustServerCertificate=True;Encrypt=False")
                .Options;

            using (var context = new ImdbContext(options))
            {
                var orderProductDal = new TbOrderProductDal(context);
                List<TbOrderProduct> orderProducts = orderProductDal.GetAll();
                // Перевірка, чи кількість отриманих записів відповідає очікуваному значенню
                Assert.AreEqual(5, orderProducts.Count);
            }
        }

        [TestMethod]
        public void DeleteOrderProduct()
        {
            var options = new DbContextOptionsBuilder<ImdbContext>()
                .UseSqlServer("Data Source=LAPTOP-BPDBP75F;Initial Catalog=programming;Integrated Security=True;TrustServerCertificate=True;Encrypt=False")
                .Options;

            using (var context = new ImdbContext(options))
            {
                var orderProductDal = new TbOrderProductDal(context);
                TbOrderProduct newOrderProduct = new TbOrderProduct();

                TbOrderProduct createdOrderProduct = orderProductDal.Insert(newOrderProduct);
                int orderId = createdOrderProduct.OrderId;
                int productId = createdOrderProduct.ProductId;

                orderProductDal.Delete(orderId, productId);

                TbOrderProduct deletedOrderProduct = orderProductDal.GetCountById(orderId, productId);
                Assert.IsNull(deletedOrderProduct);
            }
        }

        [TestMethod]
        public void GetOrderProductById()
        {
            var options = new DbContextOptionsBuilder<ImdbContext>()
                .UseSqlServer("Data Source=LAPTOP-BPDBP75F;Initial Catalog=programming;Integrated Security=True;TrustServerCertificate=True;Encrypt=False")
                .Options;

            using (var context = new ImdbContext(options))
            {
                var orderProductDal = new TbOrderProductDal(context);
                TbOrderProduct newOrderProduct = new TbOrderProduct();

                TbOrderProduct createdOrderProduct = orderProductDal.Insert(newOrderProduct);
                int orderId = createdOrderProduct.OrderId;
                int productId = createdOrderProduct.ProductId;

                TbOrderProduct retrievedOrderProduct = orderProductDal.GetCountById(orderId, productId);
                Assert.IsNotNull(retrievedOrderProduct);
                Assert.AreEqual(orderId, retrievedOrderProduct.OrderId);
                Assert.AreEqual(productId, retrievedOrderProduct.ProductId);
            }
        }

        [TestMethod]
        public void InsertOrderProduct()
        {
            var options = new DbContextOptionsBuilder<ImdbContext>()
                .UseSqlServer("Data Source=LAPTOP-BPDBP75F;Initial Catalog=programming;Integrated Security=True;TrustServerCertificate=True;Encrypt=False")
                .Options;

            using (var context = new ImdbContext(options))
            {
                var orderProductDal = new TbOrderProductDal(context);
                TbOrderProduct newOrderProduct = new TbOrderProduct();

                TbOrderProduct insertedOrderProduct = orderProductDal.Insert(newOrderProduct);
                Assert.IsNotNull(insertedOrderProduct);
                Assert.AreEqual(newOrderProduct.OrderId, insertedOrderProduct.OrderId);
                Assert.AreEqual(newOrderProduct.ProductId, insertedOrderProduct.ProductId);
            }
        }

        [TestMethod]
        public void UpdateOrderProduct()
        {
            var options = new DbContextOptionsBuilder<ImdbContext>()
                .UseSqlServer("Data Source=LAPTOP-BPDBP75F;Initial Catalog=programming;Integrated Security=True;TrustServerCertificate=True;Encrypt=False")
                .Options;

            using (var context = new ImdbContext(options))
            {
                var orderProductDal = new TbOrderProductDal(context);

                TbOrderProduct newOrderProduct = new TbOrderProduct
                {
                    ProductId = 1,
                    Count = 10
                };

                TbOrderProduct insertedOrderProduct = orderProductDal.Insert(newOrderProduct);
                int orderId = insertedOrderProduct.OrderId;
                int productId = insertedOrderProduct.ProductId;

                TbOrderProduct updatedOrderProduct = new TbOrderProduct
                {
                    OrderId = orderId,
                    ProductId = productId,
                    Count = 20
                };

                TbOrderProduct result = orderProductDal.Update(updatedOrderProduct);
                Assert.IsNotNull(result);
                Assert.AreEqual(orderId, result.OrderId);
                Assert.AreEqual(productId, result.ProductId);
                Assert.AreEqual(updatedOrderProduct.Count, result.Count);
            }
        }

    }
}
