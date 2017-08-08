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
            _db = new DatabaseInterface("BAGOLOOT_TEST_DB");
            _customerManager = new CustomerManager(_db);
        }

        [Fact]
        public void AddNewCustomer()
        {
            Customer customerToAdd = new Customer() {
                CustomerId = 13,
                Name = "Meg Ducharme",
                Address = "West Nashville",
                City = "Nashville",
                State = "TN",
                ZipCode = 37209,
                Phone = "5555555555"
            };

            List<Customer> emptyList = _customerManager.GetAllCustomers();
            Assert.True(emptyList.Count == 0);

            _customerManager.AddCustomer(customerToAdd);
            List<Customer> allCustomers = _customerManager.GetAllCustomers();
            Assert.Contains(customerToAdd, allCustomers);
        }

        [Fact]
        public void ListCustomers()
        {
            Customer newCustomer = new Customer();

            List<Customer> allCustomers = _customerManager.GetAllCustomers();
            Assert.True(allCustomers.Count == 0);

            _customerManager.AddCustomer(newCustomer);
            List<Customer> allCustomers2 = _customerManager.GetAllCustomers();
            Assert.True(allCustomers.Count > 0);

        }

        [Fact]
        public void UserShouldBeAbleToSelectActiveCustomer()
        {
            Customer selectedCustomer = new Customer() {
                CustomerId = 13,
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
                PaymentTypeId = 1,
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
                ProductId = 1,
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
       
        }
    }
}
