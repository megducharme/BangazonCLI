using System;
using Bangazon.Models;
using Xunit;

namespace Bangazon.Tests
{
    public class OrderManagerShould: IDisposable
    {

        private readonly OrderManager _orderManager;

        private DatabaseInterface _db;

        public OrderManagerShould()
        {
            _db = new DatabaseInterface("BAGOLOOT_TEST_DB");
            _orderManager = new OrderManager(_db);
        }

        [Fact]
        public void CreateNewOrder()
        {
            Product kite = new Product();
            bool newOrder = _orderManager.CreateOrder(kite);
        }

        
        [Fact]
        public void UserShouldBeAbleToAddAProductToCustomerOrder()
        {
            Product coolProduct = new Product();

            bool productAddedToOrder = _orderManager.AddProductToOrder(coolProduct);

            Assert.Equal(productAddedToOrder, true);
        }

        [Fact]
        public void GetActiveCustomerOrder()
        {
           int customerOrderId = _orderManager.GetCustomerOrder();
        }

        public void Dispose()
        {

        }
    }
}
