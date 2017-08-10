using System;
using System.Collections.Generic;
using System.Linq;
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

    public int AddCustomer(Customer newCustomer)
    {
        string sqlCmd = $"insert into customer values (null, '{newCustomer.Name}', '{newCustomer.Address}', '{newCustomer.City}', '{newCustomer.State}', {newCustomer.ZipCode}, '{newCustomer.Phone}')";
        int customerId = _db.Insert(sqlCmd);

        return customerId;
    }

    public List<Customer> GetAllCustomers()
    {
        _db.Query("select id, name, address, city, state, zip, phone from customer",
                (SqliteDataReader reader) => {
                    _allCustomers.Clear();
                    while (reader.Read ())
                    {
                        _allCustomers.Add(new Customer(){
                            Id = reader.GetInt32(0),
                            Name = reader[1].ToString(),
                            Address = reader[2].ToString(),
                            City = reader[3].ToString(),
                            State = reader[4].ToString(),
                            ZipCode = reader.GetInt32(5),
                            Phone = reader[6].ToString()
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
        Console.WriteLine("the active customer is " + activeCustomer.Name);
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

    public void SetActiveCustomer(int customerId)
    {
        _db.Query($"select {customerId}, name, address, city, state, zip, phone from customer",
                (SqliteDataReader reader) => {
                    _allCustomers.Clear();
                    while (reader.Read ())
                    {
                        CustomerManager.activeCustomer = (new Customer(){
                            Id = reader.GetInt32(0),
                            Name = reader[1].ToString(),
                            Address = reader[2].ToString(),
                            City = reader[3].ToString(),
                            State = reader[4].ToString(),
                            ZipCode = reader.GetInt32(5),
                            Phone = reader[6].ToString()
                        });
                    }
                }
            );
    }

    public Customer GetCustomer(int id) =>  _allCustomers.SingleOrDefault(customer => customer.Id == id);
}