using System;
using System.Collections.Generic;
using Bangazon.Models;

public class OrderManager
{
    private DatabaseInterface _db;

    public OrderManager(DatabaseInterface db)
    {
        _db = db;
    }
    public bool AddProductToOrder(Product produtId)
    {
        return true;
    }

    public bool CreateOrder(Product productToAdd)
    {
        return true;
    }

    public int GetCustomerOrder()
    {
        return 3;
    }
}