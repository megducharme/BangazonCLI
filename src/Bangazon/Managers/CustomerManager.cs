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
    private List<Customer> _allCustomers = new List<Customer>();
    private List<PaymentType> _activeCustomerPaymentTypes = new List<PaymentType>();
    private List<Product> _activeCustomerProducts = new List<Product>();
    public static Customer activeCustomer;

    public void AddCustomer(Customer newCustomer)
    {
        _allCustomers.Add(newCustomer);
    }

    public List<Customer> GetAllCustomers()
    {
        return _allCustomers;
    }

    public List<PaymentType> GetactiveCustomerPaymentTypes()
    {
        return _activeCustomerPaymentTypes;
    }

    public List<Product> GetCustomerProducts()
    {
        return _activeCustomerProducts;
    }

    public Customer SetactiveCustomer(Customer selectedCustomer)
    {
        activeCustomer = selectedCustomer;
        return activeCustomer;
    }

    public List<PaymentType> AddNewPaymentType(PaymentType newPaymentType)
    {
        _activeCustomerPaymentTypes.Add(newPaymentType);
        return _activeCustomerPaymentTypes;
    }

    public List<Product> AddCustomerProduct(Product newProduct)
    {
        _activeCustomerProducts.Add(newProduct);
        return _activeCustomerProducts;
    }
}