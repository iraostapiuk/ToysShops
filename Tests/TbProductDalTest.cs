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
    public class TbProductDalTest
    {
        [TestMethod]
        public void GetAllProducts()
        {
            var options = new DbContextOptionsBuilder<ImdbContext>()
                .UseSqlServer("Data Source=LAPTOP-BPDBP75F;Initial Catalog=programming;Integrated Security=True;TrustServerCertificate=True;Encrypt=False")
                .Options;

            using (var context = new ImdbContext(options))
            {
                var productDal = new TbProductDal(context);
                List<TbProduct> products = productDal.GetAll();
                // Перевірка, чи кількість отриманих записів відповідає очікуваному значенню
                Assert.AreEqual(12, products.Count);
            }
        }

        [TestMethod]
        public void DeleteProduct()
        {
            var options = new DbContextOptionsBuilder<ImdbContext>()
                .UseSqlServer("Data Source=LAPTOP-BPDBP75F;Initial Catalog=programming;Integrated Security=True;TrustServerCertificate=True;Encrypt=False")
                .Options;

            using (var context = new ImdbContext(options))
            {
                var productDal = new TbProductDal(context);
                TbProduct newProduct = new TbProduct();

                TbProduct createdProduct = productDal.Insert(newProduct);
                int productId = createdProduct.ProductId;

                productDal.Delete(productId);

                TbProduct deletedProduct = productDal.GetProductById(productId);
                Assert.IsNull(deletedProduct);
            }
        }

        [TestMethod]
        public void GetProductById()
        {
            var options = new DbContextOptionsBuilder<ImdbContext>()
                .UseSqlServer("Data Source=LAPTOP-BPDBP75F;Initial Catalog=programming;Integrated Security=True;TrustServerCertificate=True;Encrypt=False")
                .Options;

            using (var context = new ImdbContext(options))
            {
                var productDal = new TbProductDal(context);
                TbProduct newProduct = new TbProduct();

                TbProduct createdProduct = productDal.Insert(newProduct);
                int productId = createdProduct.ProductId;

                TbProduct retrievedProduct = productDal.GetProductById(productId);
                Assert.IsNotNull(retrievedProduct);
                Assert.AreEqual(productId, retrievedProduct.ProductId);
            }
        }

        [TestMethod]
        public void InsertProduct()
        {
            var options = new DbContextOptionsBuilder<ImdbContext>()
                .UseSqlServer("Data Source=LAPTOP-BPDBP75F;Initial Catalog=programming;Integrated Security=True;TrustServerCertificate=True;Encrypt=False")
                .Options;

            using (var context = new ImdbContext(options))
            {
                var productDal = new TbProductDal(context);
                TbProduct newProduct = new TbProduct();

                TbProduct insertedProduct = productDal.Insert(newProduct);
                Assert.IsNotNull(insertedProduct);
                Assert.AreEqual(newProduct.ProductId, insertedProduct.ProductId);
            }
        }

        [TestMethod]
        public void UpdateProduct()
        {
            var options = new DbContextOptionsBuilder<ImdbContext>()
                .UseSqlServer("Data Source=LAPTOP-BPDBP75F;Initial Catalog=programming;Integrated Security=True;TrustServerCertificate=True;Encrypt=False")
                .Options;

            using (var context = new ImdbContext(options))
            {
                var productDal = new TbProductDal(context);

                TbProduct newProduct = new TbProduct
                {
                    ProductName = "Назва продукту",
                    Quantity = 10,
                    Price = 100.0,
                    ProviderName = "Постачальник",
                    DateOfUpdating = DateTime.Now,
                    ProductType = "Тип продукту"
                };

                TbProduct insertedProduct = productDal.Insert(newProduct);
                int productId = insertedProduct.ProductId;

                TbProduct updatedProduct = new TbProduct
                {
                    ProductId = productId,
                    ProductName = "Нова назва продукту",
                    Quantity = 20,
                    Price = 200.0,
                    ProviderName = "Новий постачальник",
                    DateOfUpdating = DateTime.Now,
                    ProductType = "Новий тип продукту"
                };

                TbProduct result = productDal.Update(updatedProduct);
                Assert.IsNotNull(result);
                Assert.AreEqual(productId, result.ProductId);
                Assert.AreEqual(updatedProduct.ProductName, result.ProductName);
                Assert.AreEqual(updatedProduct.Quantity, result.Quantity);
                Assert.AreEqual(updatedProduct.Price, result.Price);
                Assert.AreEqual(updatedProduct.ProviderName, result.ProviderName);
                Assert.AreEqual(updatedProduct.DateOfUpdating, result.DateOfUpdating);
                Assert.AreEqual(updatedProduct.ProductType, result.ProductType);
            }
        }

    }
}
