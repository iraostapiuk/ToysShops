using DAL.Concreate;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Tests
{
    [TestClass]
    public class TbOrderDalTest
    {
        [TestMethod]

        public void GetAllOrders()
        {
            var options = new DbContextOptionsBuilder<ImdbContext>()
                .UseSqlServer("Data Source=LAPTOP-BPDBP75F;Initial Catalog=programming;Integrated Security=True;TrustServerCertificate=True;Encrypt=False")
                .Options;

            using (var context = new ImdbContext(options))
            {
                var orderDal = new TbOrderDal(context);
                List<TbOrder> orders = orderDal.GetAll();
                Assert.AreEqual(4, orders.Count);


            }
        }
        [TestMethod]
        public void DeleteOrder()
        {
            var options = new DbContextOptionsBuilder<ImdbContext>()
                .UseSqlServer("Data Source=LAPTOP-BPDBP75F;Initial Catalog=programming;Integrated Security=True;TrustServerCertificate=True;Encrypt=False")
                .Options;

            using (var context = new ImdbContext(options))
            {
                var orderDal = new TbOrderDal(context);
                TbOrder newOrder = new TbOrder();

                TbOrder createdOrder = orderDal.Insert(new TbOrder());
                int orderId = createdOrder.OrderId;

                orderDal.Delete(orderId);

                TbOrder deletedOrder = orderDal.GetOrderById(orderId);
                Assert.IsNull(deletedOrder);
            }
        }
        [TestMethod]
        public void GetOrderById()
        {
            var options = new DbContextOptionsBuilder<ImdbContext>()
                .UseSqlServer("Data Source=LAPTOP-BPDBP75F;Initial Catalog=programming;Integrated Security=True;TrustServerCertificate=True;Encrypt=False")
                .Options;

            using (var context = new ImdbContext(options))
            {
                var orderDal = new TbOrderDal(context);
                TbOrder newOrder = new TbOrder();

                TbOrder createdOrder = orderDal.Insert(new TbOrder());
                int orderId = createdOrder.OrderId;

                TbOrder retrievedOrder = orderDal.GetOrderById(orderId);
                Assert.IsNotNull(retrievedOrder);
                Assert.AreEqual(orderId, retrievedOrder.OrderId);
            }
        }
        [TestMethod]
        public void InsertOrder()
        {
            var options = new DbContextOptionsBuilder<ImdbContext>()
                .UseSqlServer("Data Source=LAPTOP-BPDBP75F;Initial Catalog=programming;Integrated Security=True;TrustServerCertificate=True;Encrypt=False")
                .Options;

            using (var context = new ImdbContext(options))
            {
                var orderDal = new TbOrderDal(context);
                TbOrder newOrder = new TbOrder();

                TbOrder insertedOrder = orderDal.Insert(newOrder);
                Assert.IsNotNull(insertedOrder);
                Assert.AreEqual(newOrder.OrderId, insertedOrder.OrderId);
            }
        }
        [TestMethod]
        public void UpdateOrder()
        {
            var options = new DbContextOptionsBuilder<ImdbContext>()
                .UseSqlServer("Data Source=LAPTOP-BPDBP75F;Initial Catalog=programming;Integrated Security=True;TrustServerCertificate=True;Encrypt=False")
                .Options;

            using (var context = new ImdbContext(options))
            {
                var orderDal = new TbOrderDal(context);

                TbOrder newOrder = new TbOrder
                {
                    OrderDate = DateTime.Now,  
                    PersonId = 1
                };

                TbOrder insertedOrder = orderDal.Insert(newOrder);
                int orderId = insertedOrder.OrderId;
                TbOrder updatedOrder = new TbOrder
                {
                    OrderId = orderId,
                    OrderDate = DateTime.Now,  
                    PersonId = 2  
                };

                TbOrder result = orderDal.Update(updatedOrder);
                Assert.IsNotNull(result);
                Assert.AreEqual(orderId, result.OrderId);
                Assert.AreEqual(updatedOrder.OrderDate, result.OrderDate);
                Assert.AreEqual(updatedOrder.PersonId, result.PersonId);
            }
        }

    }

}
