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

            Customer currentActiveCustomer = _customerManager.SelectActiveCustomer(selectedCustomer);

            Assert.Equal(selectedCustomer, currentActiveCustomer);

        }

        

        public void Dispose()
        {
            // _db.Delete("DELETE FROM toy");
            // _db.Delete("DELETE FROM child");
        }
    }
}
