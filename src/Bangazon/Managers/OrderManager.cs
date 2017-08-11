using System;
using System.Collections.Generic;
using Bangazon.Models;
using Microsoft.Data.Sqlite;

public class OrderManager
{
    public static DatabaseInterface _db;
    private List<Product> _allProducts = new List<Product>();
    public static Order _customerActiveOrder = new Order(){Id = 0};
    private List<PaymentType> _allPaymentTypes = new List<PaymentType>();

    public OrderManager(DatabaseInterface db)
    {
        _db = db;
    }

    public List<Product> GetAllProducts()
    {
        _db.Query("select id, name, quantity, price, customerId, datecreated from product",
                (SqliteDataReader reader) => {
                    _allProducts.Clear();
                    while (reader.Read ())
                    {
                        _allProducts.Add(new Product(){
                            Id = reader.GetInt32(0),
                            Name = reader[1].ToString(),
                            Quantity = reader.GetInt32(2),
                            Price = reader.GetInt32(3),
                            CustomerId = reader.GetInt32(4),
                            DateCreated = reader.GetDateTime(5)
                        });
                    }
                }
            );
        return _allProducts;
    } 

    public int AddProductToOrder(int productId)
    {
        Order activeOrder = _customerActiveOrder;
        int newOrderProductId = 0;

        if(activeOrder.Id != 0)
        {
            newOrderProductId = _db.Insert($"insert into orderproduct values(null, {activeOrder.Id}, {productId})");
            Console.WriteLine("active order isn't null, added new product to an order!");
        }
        else
        {
            int orderId = CreateOrder(CustomerManager.activeCustomer.Id);
            newOrderProductId = _db.Insert($"insert into orderproduct values(null, {orderId}, {productId})");
            Console.WriteLine(newOrderProductId + "(new orderproduct id) created a new order and added a product!");
        }
        return newOrderProductId;
    }

    public int CreateOrder(int customerId)
    {
        int newOrderId = 0;
        DateTime rightNow = DateTime.Now;

        newOrderId = _db.Insert($"insert into [order] values (null, '{rightNow}', null, {customerId}, null)");
        Console.WriteLine(newOrderId + "(new order id) created an order!");
        return newOrderId;
    }

    public static void SetActiveOrder()
    {
        Console.WriteLine("this is actually happening");
        _db.Query($"select id, datecreated, dateclosed, customerid, paymenttypeid from [order] where customerid={CustomerManager.activeCustomer.Id} and paymenttypeid is null",
                (SqliteDataReader reader) => {
                    while (reader.Read ())
                    {
                        _customerActiveOrder = new Order(){
                            Id = reader.GetInt32(0),
                            DateCreated = reader.GetDateTime(1),
                            DateClosed = reader.IsDBNull(reader.GetOrdinal("dateclosed")) ? (DateTime?) null : reader.GetDateTime(2),
                            CustomerId = reader.GetInt32(3),
                            PaymentTypeId = reader.IsDBNull(reader.GetOrdinal("PaymentTypeId")) ? (int?) null : reader.GetInt32(4)
                        };
                    Console.WriteLine("setting active order!");
                    }
                });

    }

    public List<PaymentType> GetAllPaymentTypes()
    {
        _db.Query($"select id, name, accountnumber from paymenttype where customerid={CustomerManager.activeCustomer.Id}",
                (SqliteDataReader reader) => {
                    _allPaymentTypes.Clear();
                    while (reader.Read ())
                    {
                        _allPaymentTypes.Add(new PaymentType(){
                            Id = reader.GetInt32(0),
                            Name = reader[1].ToString(),
                            AccountNumber = reader.GetInt32(2),
                            CustomerId = reader.GetInt32(2)
                        });
                    }
                }
            );
        return _allPaymentTypes;
    } 

    public int AddPaymentTypeToOrder(int paymentId)
    {
        int activeCustomerOrderId = _customerActiveOrder.Id;
        int completedOrderId = 0;

        if(activeCustomerOrderId == 0)
        {
            Console.WriteLine("You have no products in your cart! Go shopping :)");
        }
        else
        {
            completedOrderId = _db.Insert($"update [order] set paymenttypeid={paymentId} Where Id={_customerActiveOrder.Id}");
        }
        
        return completedOrderId;
    }
}