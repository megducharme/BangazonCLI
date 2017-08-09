using System;
using Bangazon.Models;
using Bangazon.Data;
using Bangazon.Actions;

namespace Bangazon
{
    class Program
    {
        static void Main(string[] args)
        {
            DatabaseInterface db = new DatabaseInterface("BANGAZONCLI_DB");
            db.CheckDatabaseTable("Customer", DbTables.Customer);
            db.CheckDatabaseTable("Product", DbTables.Product);
            db.CheckDatabaseTable("PaymentType", DbTables.PaymentType);
            db.CheckDatabaseTable("[Order]", DbTables.Order);
            db.CheckDatabaseTable("OrderProduct", DbTables.OrderProduct);
            DbInitializer.Initialize(db);

            MainMenu menu = new MainMenu();
            CustomerManager customerManager = new CustomerManager(db);
            OrderManager orderManager = new OrderManager(db);

            // Choice will hold the number entered by the user
            // after main menu ws displayed
            int choice;

            do
            {
                // Show the main menu
                choice = menu.Show();

                switch (choice)
                {
                    // Menu option 1: Add new customer
                    case 1:
                        AddCustomer.DoAction(customerManager);
                        break;

                    // Menu option 2: Choosing active customer
                    case 2:
                        ChooseActiveCustomer.DoAction(customerManager);
                        break;
                }
            } while (choice != 7);
        }
    }
}
