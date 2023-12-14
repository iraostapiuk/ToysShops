using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DAL1;
using DAL1.Concreate;
using DAL1.Abstract;
using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
          
            //Підключення до бази даних через контекст Entity Framework
            var options = new DbContextOptionsBuilder<ImdbContext>()
                .UseSqlServer("Data Source=LAPTOP-BPDBP75F;Initial Catalog=ToyShop;Integrated Security=True;TrustServerCertificate=True;Encrypt=False")
                .Options;
            var dbContext = new ImdbContext(options);
            // Створення об'єктів для роботи з DAL
            var orderDal = new OrderDal(dbContext);
            var customerDal = new CustomerDal(dbContext);
            

            Console.WriteLine("Виберіть дію:");
            Console.WriteLine("1. Показати усі замовлення");
            Console.WriteLine("2. Показати усіх клієнтів");
            Console.WriteLine("3. Знайти замовлення за id");
            Console.WriteLine("4. Знайти клієнта за id");
            Console.WriteLine("5. Видалити замовленя");
            Console.WriteLine("6. Видалити клієнта");
            Console.WriteLine("7. Оновити замовлення");
            Console.WriteLine("8. Оновити профіль клієнта");
            Console.WriteLine("9. Додати  замовлення");
            Console.WriteLine("10. Додати клієнта клієнта");
            Console.WriteLine("11. Вийти");
            while (true)
            {
                Console.Write("Ваш вибір: ");
                var choice = Console.ReadLine();

                switch (choice)
                {

                    case "1":
                        Console.WriteLine("Перегляд усіх замовлень:");
                        // Виводимо всі записи для кожної сутності
                        List<Order> allOrders = orderDal.GetAll(); // Отримуємо всі записи з таблиці TbOrder
                        foreach (var order in allOrders)
                        {
                            string formattedOrder = OrderDal.Format(order); // Форматуємо кожний об'єкт
                            Console.WriteLine(formattedOrder); // Виводимо на консоль
                        }
                        break;

                    case "2":
                        Console.WriteLine("Перегляд усіх замовлень:");
                        // Виводимо всі записи для кожної сутності
                        List<Customer> allCustomers = customerDal.GetAll(); // Отримуємо всі записи з таблиці TbOrder
                        foreach (var customer in allCustomers)
                        {
                            string formattedCustomer = CustomerDal.Format(customer);
                            Console.WriteLine(formattedCustomer); // Виводимо на консоль
                        }
                        break;

                    case "3":
                        Console.WriteLine("Пошук замовлення по id:");
                        Console.Write("Введіть Id замовлення, яке ви шукаєте: ");
                        if (int.TryParse(Console.ReadLine(), out int orderId))
                        {
                            Order order = orderDal.GetOrderById(orderId);
                            if (order != null)
                            {
                                Console.WriteLine("Знайдене замовлення:");
                                string formattedOrder = OrderDal.Format(order); // Використовуємо функцію Format
                                Console.WriteLine(formattedOrder);
                            }
                            else
                            {
                                Console.WriteLine($"Замовлення з ID {orderId} не знайдено.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Введено некоректний ID.");
                        }

                        break;

                    case "4":
                        Console.WriteLine("Пошук клієнта по id:");
                        Console.Write("Введіть Id клієнта, яке ви шукаєте: ");
                        if (int.TryParse(Console.ReadLine(), out int customerId))
                        {
                            Customer customer = customerDal.GetCustomerById(customerId);
                            if (customer != null)
                            {
                                Console.WriteLine("Знайдене замовлення:");
                                string formattedCustomer = CustomerDal.Format(customer); // Використовуємо функцію Format
                                Console.WriteLine(formattedCustomer);
                            }
                            else
                            {
                                Console.WriteLine($"Замовлення з ID {customerId} не знайдено.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Введено некоректний ID.");
                        }

                        break;
                    case "5":
                        Console.WriteLine("Видалення запису:");
                        Console.Write("Введіть ID запису, який ви бажаєте видалити: ");
                        if (int.TryParse(Console.ReadLine(), out int inputid))
                        {
                            var existingOrder = orderDal.GetOrderById(inputid);

                            if (existingOrder != null)
                            {
                                Console.WriteLine("Ви впевнені, що бажаєте видалити цей запис? (Y/N)");
                                string confirmation = Console.ReadLine();

                                if (confirmation.Equals("Y", StringComparison.OrdinalIgnoreCase))
                                {
                                    orderDal.Delete(inputid);
                                    Console.WriteLine("Запис було успішно видалено.");
                                }
                                else
                                {
                                    Console.WriteLine("Видалення скасовано.");
                                }
                            }
                            else
                            {
                                Console.WriteLine($"Запис з ID {inputid} не знайдено.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Невірний формат для ID запису.");
                        }

                        break;
                    case "6":
                        Console.WriteLine("Видалення запису:");
                        Console.Write("Введіть ID клієнта, якого ви бажаєте видалити: ");
                        if (int.TryParse(Console.ReadLine(), out int inputid2))
                        {
                            var existingCustomer = customerDal.GetCustomerById(inputid2);

                            if (existingCustomer != null)
                            {
                                Console.WriteLine("Ви впевнені, що бажаєте видалити цей запис? (Y/N)");
                                string confirmation = Console.ReadLine();

                                if (confirmation.Equals("Y", StringComparison.OrdinalIgnoreCase))
                                {
                                    customerDal.Delete(inputid2);
                                    Console.WriteLine("Запис було успішно видалено.");
                                }
                                else
                                {
                                    Console.WriteLine("Видалення скасовано.");
                                }
                            }
                            else
                            {
                                Console.WriteLine($"Запис з ID {inputid2} не знайдено.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Невірний формат для ID запису.");
                        }

                        break;
                    case "7":
                        Console.WriteLine("Оновлення запису:");

                        Console.Write("Введіть ID запису, який ви бажаєте оновити: ");
                        if (int.TryParse(Console.ReadLine(), out int id))
                        {
                            var existingOrder = orderDal.GetOrderById(id);

                            if (existingOrder != null)
                            {
                                Console.WriteLine("Поточні значення:");
                                Console.WriteLine($"PersonId: {existingOrder.CustomerId}");
                                Console.WriteLine($"OrderDate: {existingOrder.OrderDate}");
                                // Виводьте поточні значення для інших полів, якщо потрібно


                                Console.Write("Введіть нове значення для OrderDate (у форматі yyyy-MM-dd): ");
                                if (DateTime.TryParse(Console.ReadLine(), out DateTime newOrderDate))
                                {
                                    existingOrder.OrderDate = newOrderDate;
                                }
                                else
                                {
                                    Console.WriteLine("Невірний формат для OrderDate.");
                                    return;
                                }
                                Console.Write("Введіть нове значення для PersonId: ");
                                if (int.TryParse(Console.ReadLine(), out int newPersonId))
                                {
                                    existingOrder.CustomerId = newPersonId;
                                }
                                else
                                {
                                    Console.WriteLine("Невірний формат для PersonId.");
                                    return;
                                }

                                // Оновлюємо запис
                                var updatedOrder = orderDal.Update(existingOrder);
                                Console.WriteLine("Запис було оновлено.");
                            }
                            else
                            {
                                Console.WriteLine($"Запис з ID {id} не знайдено.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Невірний формат для ID запису.");
                        }

                        break;
                    case "8":
                        Console.WriteLine("Оновлення профілю клієнта:");

                        Console.Write("Введіть ID запису, який ви бажаєте оновити: ");
                        if (int.TryParse(Console.ReadLine(), out int id2))
                        {
                            var existingCustomer = customerDal.GetCustomerById(id2);

                            if (existingCustomer != null)
                            {
                                Console.WriteLine("Поточні значення:");
                                Console.WriteLine($"CustomerId: {existingCustomer.CustomerId}");
                                Console.WriteLine($"FirstName: {existingCustomer.FirstName}");
                                Console.WriteLine($"LastName: {existingCustomer.LastName}");
                                Console.WriteLine($"CityAdress: {existingCustomer.AddressCity}");
                                Console.WriteLine($"Phone: {existingCustomer.Phone}");
                                

                                Console.Write("Введіть нове значення для CustomerFirstName ");
                                string newCustomerFirstName = Console.ReadLine();
                                if (!string.IsNullOrEmpty(newCustomerFirstName))
                                {
                                    existingCustomer.FirstName = newCustomerFirstName;
                                }
                                else
                                {
                                    Console.WriteLine("Невірний формат для FirstName.");
                                    return;
                                }
                                Console.Write("Введіть нове значення для LastName: ");
                                string newLastName = Console.ReadLine();
                                if (!string.IsNullOrEmpty(newLastName))
                                {
                                    existingCustomer.LastName = newLastName;
                                }

                                Console.Write("Введіть нове значення для AddressCity: ");
                                string newAddressCity = Console.ReadLine();
                                if (!string.IsNullOrEmpty(newAddressCity))
                                {
                                    existingCustomer.AddressCity = newAddressCity;
                                }

                                Console.Write("Введіть нове значення для Phone: ");
                                string newPhone = Console.ReadLine();
                                if (!string.IsNullOrEmpty(newPhone))
                                {
                                    existingCustomer.Phone = newPhone;
                                }

                                // Оновлюємо запис
                                var updatedCustomer = customerDal.Update(existingCustomer);
                                Console.WriteLine("Запис було оновлено.");
                            }
                            else
                            {
                                Console.WriteLine($"Запис з ID {id2} не знайдено.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Невірний формат для ID запису.");
                        }

                        break;
                    case "9":
                        // Створюємо новий об'єкт TbOrder
                        Order newOrder = new Order();
              

                        Console.Write("Введіть PersonId: ");
                        if (int.TryParse(Console.ReadLine(), out int personId))
                        {
                            newOrder.CustomerId = personId;
                        }
                        else
                        {
                            Console.WriteLine("Невірний формат для PersonId.");
                            return;
                        }

                        Console.Write("Введіть OrderDate (у форматі yyyy-MM-dd): ");
                        if (DateTime.TryParse(Console.ReadLine(), out DateTime orderDate))
                        {
                            newOrder.OrderDate = orderDate;
                        }
                        else
                        {
                            Console.WriteLine("Невірний формат для OrderDate.");
                            return;
                        }

                        Order insertedOrder = orderDal.Insert(newOrder);

                        Console.WriteLine($"Новий запис був доданий. ID нового запису: {insertedOrder.OrderId}");
                        return;
                    case "10":
                        Customer newCustomer = new Customer();

                        //Console.Write("Введіть CustomerID: ");
                        //if (int.TryParse(Console.ReadLine(), out int customerId2))
                        //{
                        //    newCustomer.CustomerId = customerId2;
                        //}
                        //else
                        //{
                        //    Console.WriteLine("Невірний формат для CustomerID.");
                        //    return;
                        //}

                        Console.Write("Введіть FirstName: ");
                        string firstName = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(firstName))
                        {
                            newCustomer.FirstName = firstName;
                        }
                        else
                        {
                            Console.WriteLine("FirstName не може бути пустим або містити пробіли.");
                            return;
                        }

                        Console.Write("Введіть LastName: ");
                        string lastName = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(lastName))
                        {
                            newCustomer.LastName = lastName;
                        }
                        else
                        {
                            Console.WriteLine("LastName не може бути пустим або містити пробіли.");
                            return;
                        }

                        Console.Write("Введіть AddressCity: ");
                        string addressCity = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(addressCity))
                        {
                            newCustomer.AddressCity = addressCity;
                        }
                        else
                        {
                            Console.WriteLine("AddressCity не може бути пустим або містити пробіли.");
                            return;
                        }

                        Console.Write("Введіть Phone: ");
                        string phone = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(phone))
                        {
                            newCustomer.Phone = phone;
                        }
                        else
                        {
                            Console.WriteLine("Phone не може бути пустим або містити пробіли.");
                            return;
                        }

                        // Додаємо нового клієнта до бази даних
                        Customer insertedCustomer = customerDal.Insert(newCustomer);

                        Console.WriteLine($"Новий запис був доданий. ID нового запису: {insertedCustomer.CustomerId}");
                        return;

                    case "11":
                        Console.WriteLine("Дякую, що скористалися програмою.");
                        return;

                    default:
                        Console.WriteLine("Невірний вибір. Будь ласка, виберіть правильну опцію.");
                        break;
                }
            }
        }
    }


}

