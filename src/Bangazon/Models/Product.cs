using System;

namespace Bangazon.Models
{
    public class Product
    {
        public int Id {get;set;}
        public string Name {get;set;}
        public int Quantity {get;set;}
        public double Price {get;set;}
        public int CustomerId {get;set;}
        public DateTime DateCreated;
    }
}