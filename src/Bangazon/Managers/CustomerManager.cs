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
    public static Customer activeCustomer = new Customer(){Name = "There is no active customer!"};

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

    public int AddNewPaymentType(PaymentType newPaymentType)
    {
        int paymentTypeId = 0;

        string sqlCmd = $"insert into paymentType values (null, '{newPaymentType.Name}', {newPaymentType.AccountNumber},{newPaymentType.CustomerId})";
        paymentTypeId = _db.Insert(sqlCmd);

        _activeCustomerPaymentTypes.Add(newPaymentType);

        return paymentTypeId;
    }

    public int AddCustomerProduct(Product newProduct)
    {
        int productId = 0;

        string sqlCmd = $"insert into product values (null, '{newProduct.Name}', {newProduct.Quantity}, {newProduct.Price}, {newProduct.CustomerId}, '{newProduct.DateCreated}')";
        productId = _db.Insert(sqlCmd);

        _activeCustomerProducts.Add(newProduct);

        return productId;
    }

    public Customer GetCustomer(int id) =>  _allCustomers.SingleOrDefault(customer => customer.Id == id);
}