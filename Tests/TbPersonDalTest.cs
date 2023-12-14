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
    public class TbPersonDalTest
    {
        [TestMethod]
        public void GetAllPeople()
        {
            var options = new DbContextOptionsBuilder<ImdbContext>()
                .UseSqlServer("Data Source=LAPTOP-BPDBP75F;Initial Catalog=programming;Integrated Security=True;TrustServerCertificate=True;Encrypt=False")
                .Options;

            using (var context = new ImdbContext(options))
            {
                var personDal = new TbPersonDal(context);
                List<TbPerson> people = personDal.GetAll();
                
                Assert.AreEqual(3, people.Count);
            }
        }

        [TestMethod]
        public void DeletePerson()
        {
            var options = new DbContextOptionsBuilder<ImdbContext>()
                .UseSqlServer("Data Source=LAPTOP-BPDBP75F;Initial Catalog=programming;Integrated Security=True;TrustServerCertificate=True;Encrypt=False")
                .Options;

            using (var context = new ImdbContext(options))
            {
                var personDal = new TbPersonDal(context);
                TbPerson newPerson = new TbPerson();

                TbPerson createdPerson = personDal.Insert(newPerson);
                int personId = createdPerson.PersonId;

                personDal.Delete(personId);

                TbPerson deletedPerson = personDal.GetPersonById(personId);
                Assert.IsNull(deletedPerson);
            }
        }

        [TestMethod]
        public void GetPersonById()
        {
            var options = new DbContextOptionsBuilder<ImdbContext>()
               .UseSqlServer("Data Source=LAPTOP-BPDBP75F;Initial Catalog=programming;Integrated Security=True;TrustServerCertificate=True;Encrypt=False")
               .Options;

            using (var context = new ImdbContext(options))
            {
                var personDal = new TbPersonDal(context);
                TbPerson newPerson = new TbPerson();

                TbPerson createdPerson = personDal.Insert(newPerson);
                int personId = createdPerson.PersonId;

                TbPerson retrievedPerson = personDal.GetPersonById(personId);
                Assert.IsNotNull(retrievedPerson);
                Assert.AreEqual(personId, retrievedPerson.PersonId);
            }
        }

        [TestMethod]
        public void InsertPerson()
        {
            var options = new DbContextOptionsBuilder<ImdbContext>()
                .UseSqlServer("Data Source=LAPTOP-BPDBP75F;Initial Catalog=programming;Integrated Security=True;TrustServerCertificate=True;Encrypt=False")
                .Options;

            using (var context = new ImdbContext(options))
            {
                var personDal = new TbPersonDal(context);
                TbPerson newPerson = new TbPerson();

                TbPerson insertedPerson = personDal.Insert(newPerson);
                Assert.IsNotNull(insertedPerson);
                Assert.AreEqual(newPerson.PersonId, insertedPerson.PersonId);
            }
        }

        [TestMethod]
        public void UpdatePerson()
        {
            var options = new DbContextOptionsBuilder<ImdbContext>()
                .UseSqlServer("Data Source=LAPTOP-BPDBP75F;Initial Catalog=programming;Integrated Security=True;TrustServerCertificate=True;Encrypt=False")
                .Options;

            using (var context = new ImdbContext(options))
            {
                var personDal = new TbPersonDal(context);

                TbPerson newPerson = new TbPerson
                {
                    FirstName = "Ім'я",
                    LastName = "Прізвище",
                    Login = "логін",
                    Password = "пароль"
                };

                TbPerson insertedPerson = personDal.Insert(newPerson);
                int personId = insertedPerson.PersonId;

                TbPerson updatedPerson = new TbPerson
                {
                    PersonId = personId,
                    FirstName = "Нове Ім'я",
                    LastName = "Нове Прізвище",
                    Login = "новий_логін",
                    Password = "новий_пароль"
                };

                TbPerson result = personDal.Update(updatedPerson);
                Assert.IsNotNull(result);
                Assert.AreEqual(personId, result.PersonId);
                Assert.AreEqual(updatedPerson.FirstName, result.FirstName);
                Assert.AreEqual(updatedPerson.LastName, result.LastName);
                Assert.AreEqual(updatedPerson.Login, result.Login);
                Assert.AreEqual(updatedPerson.Password, result.Password);
            }
        }

    }
}
