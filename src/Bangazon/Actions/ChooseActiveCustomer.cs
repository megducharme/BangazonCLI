using System;
using System.Collections.Generic;
using Bangazon.Models;

namespace Bangazon.Actions
{
    public class ChooseActiveCustomer
    {
    public static void DoAction(CustomerManager customerManager)
    {
        Console.Clear();
        Console.WriteLine ("Choose active customer");

        List<Customer> customers = customerManager.GetAllCustomers();

        foreach (Customer customer in customers)
        {
            Console.WriteLine($"{customer.Id}. {customer.Name}");
        }

        Console.Write ("> ");
        string customerId = Console.ReadLine();
        Customer chosenCustomer = customerManager.GetCustomer(int.Parse(customerId));
        CustomerManager.activeCustomer = chosenCustomer;
    }
    }
}