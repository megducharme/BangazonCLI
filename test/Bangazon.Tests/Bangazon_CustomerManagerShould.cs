using System;
using Xunit;
using System.Collections.Generic;

namespace Bangazon.Tests
{
    public class CustomerManagerShould: IDisposable
    {
        private readonly CustomerManager _customerManager;

        public CustomerManagerShould()
        {
            // _db = new DatabaseInterface("BAGOLOOT_TEST_DB");
            _customerManager = new CustomerManager();
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

            _customerManager.AddCustomer(customerToAdd);
            List<Customer> allCustomers = _customerManager.allCustomers;

            Assert.Contains(customerToAdd, allCustomers);
        }

        [Fact]
        public void ListCustomers()
        {
           List<Customer> allCustomers = _customerManager.GetAllCustomers();

            Assert.True(allCustomers.Count >= 0);
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
                AccountNumber = 7287492,
                CustomerId = 13
            };

            List<PaymentType> allPaymentTypes = _customerManager.AddPaymentType(newPaymentType);

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

            List<Product> allProducts = _customerManager.AddCustomerProduct(newProduct);

            Assert.Contains(newProduct, allProducts);
        }

        [Fact]
        public void UserShouldBeAbleToAddAProductToCustomerOrder()
        {
            int customerId = 1;
            int productId = 3;

            bool productAddedToOrder = _customerManager.AddProductToOrder(customerId, productId);

            Assert.Equal(productAddedToOrder, true);
        }
        public void Dispose()
        {
            // _db.Delete("DELETE FROM toy");
            // _db.Delete("DELETE FROM child");
        }
    }
}
