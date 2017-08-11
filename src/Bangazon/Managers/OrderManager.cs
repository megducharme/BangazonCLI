using System;
using System.Collections.Generic;
using Bangazon.Models;
using Microsoft.Data.Sqlite;

public class OrderManager
{
    private DatabaseInterface _db;
    private List<Product> _allProducts = new List<Product>();
    public static Order _customerActiveOrder = null;

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
        SetActiveOrder();
        Order activeOrder = _customerActiveOrder;
        int newOrderProductId = 0;

        if(activeOrder != null)
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

    public void SetActiveOrder()
    {
        _db.Query($"select * from [order] where customerid={CustomerManager.activeCustomer.Id} and paymenttypeId=null",
                (SqliteDataReader reader) => {
                    while (reader.Read ())
                    {
                        _customerActiveOrder = new Order(){
                            Id = reader.GetInt32(0),
                            DateCreated = reader.GetDateTime(1),
                            DateClosed = reader.GetDateTime(2),
                            CustomerId = reader.GetInt32(3),
                            PaymentId = reader.GetInt32(4)
                        };
                    Console.WriteLine("setting active order!");
                    }
                }
            );

    }
}