using System;
using Xunit;
using System.Collections.Generic;
using Bangazon.Models;

namespace Bangazon.Tests
{
    public class CustomerManagerShould: IDisposable
    {
        private readonly CustomerManager _customerManager;
        private DatabaseInterface _db;

        public CustomerManagerShould()
        {
            _db = new DatabaseInterface("BANGAZON_TEST_DB");
            _customerManager = new CustomerManager(_db);
            _db.CheckDatabaseTable("Customer", DbTables.Customer);
            _db.CheckDatabaseTable("Product", DbTables.Product);
            _db.CheckDatabaseTable("PaymentType", DbTables.PaymentType);
            _db.CheckDatabaseTable("[Order]", DbTables.Order);
            _db.CheckDatabaseTable("OrderProduct", DbTables.OrderProduct);
        }

        [Fact]
        public void AddNewCustomer()
        {

            Customer customerToAdd = new Customer() {
                Name = "Meg Ducharme",
                Address = "West Nashville",
                City = "Nashville",
                State = "TN",
                ZipCode = 37209,
                Phone = "5555555555"
            };

            Console.WriteLine(customerToAdd.ZipCode);

            List<Customer> emptyList = _customerManager.GetAllCustomers();
            Assert.True(emptyList.Count == 0);

            int customerId = _customerManager.AddCustomer(customerToAdd);
            customerToAdd.Id = customerId;

            List<Customer> allCustomers = _customerManager.GetAllCustomers();
            Assert.Equal(customerToAdd.Name, allCustomers[0].Name);
            Assert.Equal(customerToAdd.Address, allCustomers[0].Address);
            Assert.Equal(customerToAdd.City, allCustomers[0].City);
            Assert.Equal(customerToAdd.State, allCustomers[0].State);
            Assert.Equal(customerToAdd.ZipCode, allCustomers[0].ZipCode);
            Assert.Equal(customerToAdd.Phone, allCustomers[0].Phone);
        }

        [Fact]
        public void ListCustomers()
        {
            Customer newCustomer = new Customer();

            List<Customer> allCustomers = _customerManager.GetAllCustomers();
            Console.WriteLine("should be 0 here " + allCustomers.Count);
            Assert.True(allCustomers.Count == 0);

            _customerManager.AddCustomer(newCustomer);

            List<Customer> allCustomers2 = _customerManager.GetAllCustomers();
            Console.WriteLine("should be 1 here " + allCustomers2.Count);
            Assert.True(allCustomers.Count > 0);

        }

        [Fact]
        public void UserShouldBeAbleToSelectActiveCustomer()
        {
            Customer selectedCustomer = new Customer() {
                Name = "Meg Ducharme",
                Address = "West Nashville",
                City = "Nashville",
                State = "TN",
                ZipCode = 37209,
                Phone = "5555555555"
            };

            Customer currentActiveCustomer = _customerManager.SetActiveCustomer(selectedCustomer);
            Assert.Equal(selectedCustomer, currentActiveCustomer);

        }

        [Fact]
        public void UserShouldBeAbleToAddPaymentTypeForCustomer()
        {

            PaymentType newPaymentType = new PaymentType() {
                Id = 1,
                Name = "Visa",
                AccountNumber = 7287492,
                CustomerId = 13
            };

            List<PaymentType> emptyList = _customerManager.GetActiveCustomerPaymentTypes();
            Assert.True(emptyList.Count == 0);

            List<PaymentType> allPaymentTypes = _customerManager.AddNewPaymentType(newPaymentType);
            Assert.Contains(newPaymentType, allPaymentTypes);
        }

        [Fact]
        public void UserSHouldBeAbleToAddAProductForACustomer()
        {
            Product newProduct = new Product(){
                Name = "Computer",
                Quantity = 2,
                Price = 1200.00,
                CustomerId = 13,
                DateCreated = DateTime.Now
            };

            List<Product> emptyProductList = _customerManager.GetCustomerProducts();
            Assert.True(emptyProductList.Count == 0);

            List<Product> allProducts = _customerManager.AddCustomerProduct(newProduct);
            Assert.Contains(newProduct, allProducts);
        }
        public void Dispose()
        {
            _db.Delete("DELETE FROM customer");
        }
    }
}
