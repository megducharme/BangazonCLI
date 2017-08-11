using System;
using Bangazon.Models;
using Microsoft.Data.Sqlite;

namespace Bangazon.Data
{
    public static class DbInitializer
    {
        public static void Initialize(DatabaseInterface db)
        {
            bool customersExist = false;
            db.Query($"select id from customer",
            (SqliteDataReader reader) => {
                while (reader.Read())
                {
                    //reader.Read() will read the result of the query stored in reader
                    //if there is something to read (something in the db) then set customersExist to true to exit the loop
                    customersExist = true;
                }
                    //if it did run, it will exit the loop, but customers exist will now be true never executing the if block of code
                    //if it is immediately false, it will not run the while block, and move on to the if and seed the db
                    if(customersExist == false)
                    {
                        db.BulkInsert($@"
                            insert into customer values (null, 'Meg Ducharme', 'West Nashville', 'Nashville', 'TN', 37209, '55555555555');
                            insert into customer values (null, 'Kyle Ducharme', 'West Nashville', 'Nashville', 'TN', 37209, '55555555555');
                            insert into customer values (null, 'Meg Armstrong', 'West Nashville', 'Nashville', 'TN', 37209, '55555555555');
                            insert into customer values (null, 'Colleen Ducharme', 'West Nashville', 'Nashville', 'TN', 37209, '55555555555');

                            insert into product values (null, 'Flowers', 4, 20.50, '2017-08-10 10:55:44.000', 1);
                            insert into product values (null, 'Chair', 14, 29.99, '2017-08-11 10:55:44.000', 1);
                            insert into product values (null, 'Cup', 56, 9.99, '2017-08-09 10:55:44.000', 1);
                            insert into product values (null, 'Purse', 2, 129.99, '2017-08-08 10:55:44.000', 1);

                            insert into paymenttype values (null, 'Visa', '9826745', 1);
                            insert into paymenttype values (null, 'MasterCard', '9845745', 2);
                            insert into paymenttype values (null, 'Chase', '2116745', 1);
                            insert into paymenttype values (null, 'Visa', '9826745', 3);

                            insert into [order] values (null, '2017/08/08', '2017-08-11 10:55:44.000', 2, 1);
                            insert into [order] values (null, '2017/08/08', '2017-08-12 10:55:44.000', 3, 4);
                            insert into [order] values (null, '2017/07/08', '2017-08-15 10:55:44.000', 3, 4);
                            insert into [order] values (null, '2017/07/08', '2017-08-14 10:55:44.000', 1, 3);

                            insert into orderproduct values (null, 1, 3);
                            insert into orderproduct values (null, 1, 4);
                            insert into orderproduct values (null, 1, 5);
                            insert into orderproduct values (null, 2, 3);

                        ");
                    }
                
            });
        }
    }
}