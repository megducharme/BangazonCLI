using System;

namespace Bangazon.Models
{
    public class DbTables
    {
        public static string Product
        {
            get
            {
                return $@"create table product (
                                `id`	integer NOT NULL PRIMARY KEY AUTOINCREMENT,
                                `name`	varchar(80) not null, 
                                `quantity` integer not null default 0,
                                `price` integer not null,
                                `datecreated` datetime not null,
                                CustomerId INTEGER NOT NULL,
                                FOREIGN KEY (CustomerId) REFERENCES Customer(CustomerId))";
            }
        }
        
        public static string Customer
        {
            get
            {
                return $@"create table customer (
                                `id`	integer NOT NULL PRIMARY KEY AUTOINCREMENT,
                                `name`	varchar(80) not null, 
                                `address` varchar(80) not null,
                                `city` varchar(80) not null,
                                `zip` integer not null,
                                `phone` integer not null)";
            }
        }

        public static string PaymentType 
        {
            get
            {
                return $@"create table paymenttype (
                                `id`	integer NOT NULL PRIMARY KEY AUTOINCREMENT,
                                `name`	varchar(80) not null, 
                                `accountnumber` integer not null,
                                CustomerId INTEGER NOT NULL,
                                FOREIGN KEY (CustomerId) REFERENCES Customer(CustomerId))";
            }
        }

        public static string Order 
        {
            get
            {
                return $@"create table [order] (
                                `id` integer NOT NULL PRIMARY KEY AUTOINCREMENT,
                                `datecreated` datetime not null,
                                `dateclosed` datetime, 
                                `accountnumber` integer not null,
                                CustomerId INTEGER NOT NULL,
                                PaymentTypeId INTEGER NOT NULL,
                                FOREIGN KEY (CustomerId) REFERENCES Customer(CustomerId),
                                FOREIGN KEY (PaymentTypeId) REFERENCES PaymentType(PaymentTypeId))";
            }
        }
        public static string OrderProduct
        {
            get
            {
                return $@"create table orderproduct (
                                `id`	integer NOT NULL PRIMARY KEY AUTOINCREMENT,
                                CustomerId INTEGER NOT NULL,
                                ProductId INTEGER NOT NULL,
                                FOREIGN KEY (CustomerId) REFERENCES Customer(CustomerId),
                                FOREIGN KEY (ProductId) REFERENCES Product(ProductId))";
            }
        }
    }
}