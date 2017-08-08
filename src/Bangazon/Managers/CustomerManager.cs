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
    private List<PaymentType> _ActiveCustomerPaymentTypes = new List<PaymentType>();
    private List<Product> _ActiveCustomerProducts = new List<Product>();
    public Customer ActiveCustomer;

    public void AddCustomer(Customer newCustomer)
    {
        _AllCustomers.Add(newCustomer);
    }

    public List<Customer> GetAllCustomers()
    {
        return _AllCustomers;
    }

    public List<PaymentType> GetActiveCustomerPaymentTypes()
    {
        return _ActiveCustomerPaymentTypes;
    }

    public List<Product> GetCustomerProducts()
    {
        return _ActiveCustomerProducts;
    }

    public Customer SetActiveCustomer(Customer selectedCustomer)
    {
        ActiveCustomer = selectedCustomer;
        return ActiveCustomer;
    }

    public List<PaymentType> AddNewPaymentType(PaymentType newPaymentType)
    {
        _ActiveCustomerPaymentTypes.Add(newPaymentType);
        return _ActiveCustomerPaymentTypes;
    }

    public List<Product> AddCustomerProduct(Product newProduct)
    {
        _ActiveCustomerProducts.Add(newProduct);
        return _ActiveCustomerProducts;
    }
}