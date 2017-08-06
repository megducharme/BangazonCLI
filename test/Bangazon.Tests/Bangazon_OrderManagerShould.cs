using System;
using Xunit;

namespace Bangazon.Tests
{
    public class OrderManagerShould
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
            int customerId = 1;
            Product coolProduct = new Product();

            bool productAddedToOrder = _orderManager.AddProductToOrder(customerId, coolProduct);

            Assert.Equal(productAddedToOrder, true);
        }
    }
}
