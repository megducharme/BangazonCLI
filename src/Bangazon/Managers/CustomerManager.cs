using System;
using System.Collections.Generic;
using Bangazon.Models;


public class CustomerManager
{
    private DatabaseInterface _db;

    public CustomerManager(DatabaseInterface db)
    {
        _db = db;
    }
    private List<Customer> _AllCustomers = new List<Customer>();
    private List<PaymentType> _AllActiveCustomerPaymentTypes = new List<PaymentType>();
    private List<Product> _AllProducts = new List<Product>();
    public Customer ActiveCustomer;

    public void AddCustomer(Customer newCustomer)
    {
        _AllCustomers.Add(newCustomer);
    }

    public List<Customer> GetAllCustomers()
    {
        return _AllCustomers;
    }

    public Customer SetActiveCustomer(Customer selectedCustomer)
    {
        ActiveCustomer = selectedCustomer;
        return ActiveCustomer;
    }

    public List<PaymentType> AddNewPaymentType(PaymentType newPaymentType)
    {
        _AllActiveCustomerPaymentTypes.Add(newPaymentType);
        return _AllActiveCustomerPaymentTypes;
    }

    public List<Product> AddCustomerProduct(Product newProduct)
    {
        _AllProducts.Add(newProduct);
        return _AllProducts;
    }
}