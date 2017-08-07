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
                    //if it is immediately false, it will not run moving on to the if
                    //if it did run, it will exit the loop, but customers exist will now be true never executing the if block of code
                    if(customersExist == false)
                    {
                        db.BulkInsert($@"
                            insert into customer values (null, 'Meg Ducharme', 'West Nashville', 'Nashville', 37209, '55555555555');
                            insert into customer values (null, 'Kyle Ducharme', 'West Nashville', 'Nashville', 37209, '55555555555');
                            insert into customer values (null, 'Meg Armstrong', 'West Nashville', 'Nashville', 37209, '55555555555');
                            insert into customer values (null, 'Colleen Ducharme', 'West Nashville', 'Nashville', 37209, '55555555555');

                            insert into product values (null, 'Flowers', 4, 20.50, '2017/08/06', 1);
                            insert into product values (null, 'Chair', 14, 29.99, '2017/08/06', 1);
                            insert into product values (null, 'Cup', 56, 9.99, '2017/08/06', 1);
                            insert into product values (null, 'Purse', 2, 129.99, '2017/08/06', 1);

                            ");
                    }
                
            });
        }
    }
}