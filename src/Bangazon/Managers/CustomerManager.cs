using System;
using System.Collections.Generic;
using Bangazon.Models;
using Microsoft.Data.Sqlite;


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
        string sqlCmd = $"insert into customer values (null, '{newCustomer.Name}', '{newCustomer.Address}', '{newCustomer.City}', '{newCustomer.State}', {newCustomer.ZipCode}, '{newCustomer.Phone}')";
        _db.Insert(sqlCmd);
    }

    public List<Customer> GetAllCustomers()
    {
        _db.Query("select * from customer",
                (SqliteDataReader reader) => {
                    _allCustomers.Clear();
                    while (reader.Read ())
                    {
                        _allCustomers.Add(new Customer(){
                            Name = reader[1].ToString(),
                            Address = reader[1].ToString(),
                            City = reader[1].ToString(),
                            State = reader[1].ToString(),
                            ZipCode = reader.GetInt32(2),
                            Phone = reader[1].ToString()
                        });
                    }
                }
            );
        return _allCustomers;
    }

    public List<PaymentType> GetActiveCustomerPaymentTypes()
    {
        return _activeCustomerPaymentTypes;
    }

    public List<Product> GetCustomerProducts()
    {
        return _activeCustomerProducts;
    }

    public Customer SetActiveCustomer(Customer selectedCustomer)
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