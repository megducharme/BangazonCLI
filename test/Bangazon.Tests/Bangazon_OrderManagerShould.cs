using System;
using Bangazon.Models;
using Xunit;

namespace Bangazon.Tests
{
    public class OrderManagerShould: IDisposable
    {

        private readonly OrderManager _orderManager;

        public OrderManagerShould()
        {
            _orderManager = new OrderManager();
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
            // _db.Delete("DELETE FROM toy");
            // _db.Delete("DELETE FROM child");
        }
    }
}
