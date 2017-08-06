using System;

namespace Bangazon.Models
{
    public class Order
    {
        public int OrderId {get;set;}
        public DateTime DateCreated {get;set;}
        public int CustomerId {get;set;}
        public int PaymentId {get;set;}
    }
}