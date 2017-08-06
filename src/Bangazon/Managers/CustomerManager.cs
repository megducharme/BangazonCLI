using System;
using System.Collections.Generic;


public class CustomerManager
{
    public List<Customer> allCustomers = new List<Customer>();
    public List<PaymentType> AllActiveCustomerPaymentTypes = new List<PaymentType>();
    public List<Product> AllProducts = new List<Product>();
    public Customer ActiveCustomer;

    public void AddCustomer(Customer newCustomer)
    {
        allCustomers.Add(newCustomer);
    }

    public List<Customer> GetAllCustomers()
    {
        return allCustomers;
    }

    public Customer SetActiveCustomer(Customer selectedCustomer)
    {
        ActiveCustomer = selectedCustomer;
        return ActiveCustomer;
    }

    public List<PaymentType> AddNewPaymentType(PaymentType newPaymentType)
    {
        AllActiveCustomerPaymentTypes.Add(newPaymentType);
        return AllActiveCustomerPaymentTypes;
    }

    public List<Product> AddCustomerProduct(Product newProduct)
    {
        AllProducts.Add(newProduct);
        return AllProducts;
    }
}