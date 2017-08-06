using System;
using System.Collections.Generic;


public class CustomerManager
{
    public List<Customer> allCustomers = new List<Customer>();
    public Customer ActiveCustomer;

    public void AddCustomer(Customer newCustomer)
    {
        allCustomers.Add(newCustomer);
    }

    public List<Customer> GetAllCustomers()
    {
        return allCustomers;
    }

    public Customer SelectActiveCustomer(Customer selectedCustomer)
    {
        ActiveCustomer = selectedCustomer;
        return ActiveCustomer;
    }
}