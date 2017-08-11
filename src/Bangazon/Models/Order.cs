using System;

namespace Bangazon.Models
{
    public class Order
    {
        public int Id {get;set;}
        public DateTime DateCreated {get;set;}
        public DateTime? DateClosed {get;set;}
        public int CustomerId {get;set;}
        public int? PaymentId {get;set;}
    }
}