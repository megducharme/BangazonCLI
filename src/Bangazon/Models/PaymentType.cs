using System;

namespace Bangazon.Models
{
    public class PaymentType
    {
        public int PaymentTypeId {get;set;}
        public string Name {get;set;}
        public int AccountNumber {get;set;}
        public int CustomerId {get;set;}
    }
}