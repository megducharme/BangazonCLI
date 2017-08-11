using System;

namespace Bangazon.Models
{
    public class DbTables
    {
        public static string Product = $@"create table product (
                                `id`	integer NOT NULL PRIMARY KEY AUTOINCREMENT,
                                `name`	varchar(80) not null, 
                                `quantity` integer not null default 0,
                                `price` integer not null,
                                `datecreated` datetime not null,
                                CustomerId INTEGER NOT NULL,
                                FOREIGN KEY (Id) REFERENCES Customer(Id))";
        
        public static string Customer = $@"create table customer (
                                `id`	integer NOT NULL PRIMARY KEY AUTOINCREMENT,
                                `name`	varchar(80) not null, 
                                `address` varchar(80) not null,
                                `city` varchar(80) not null,
                                `state` varchar(80) not null,
                                `zip` integer not null,
                                `phone` integer not null)";

        public static string PaymentType = $@"create table paymenttype (
                                `id`	integer NOT NULL PRIMARY KEY AUTOINCREMENT,
                                `name`	varchar(80) not null, 
                                `accountnumber` integer not null,
                                CustomerId INTEGER NOT NULL,
                                FOREIGN KEY (Id) REFERENCES Customer(Id))";

        public static string Order = $@"create table [order] (
                                `id` integer NOT NULL PRIMARY KEY AUTOINCREMENT,
                                `datecreated` datetime not null,
                                `dateclosed` datetime, 
                                CustomerId INTEGER NOT NULL,
                                PaymentTypeId INTEGER,
                                FOREIGN KEY (Id) REFERENCES Customer(Id),
                                FOREIGN KEY (Id) REFERENCES PaymentType(Id))";

        public static string OrderProduct = $@"create table orderproduct (
                                `id`	integer NOT NULL PRIMARY KEY AUTOINCREMENT,
                                CustomerId INTEGER NOT NULL,
                                ProductId INTEGER NOT NULL,
                                FOREIGN KEY (Id) REFERENCES Customer(Id),
                                FOREIGN KEY (Id) REFERENCES Product(Id))";
    }
}