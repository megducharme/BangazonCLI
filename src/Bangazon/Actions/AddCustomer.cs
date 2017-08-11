using System;
using System.Collections.Generic;
using Bangazon.Models;

namespace Bangazon.Actions
{
  public class AddCustomer
  {
    public static void DoAction(CustomerManager customerManager)
    {

        Console.Clear();
        Console.WriteLine ("Enter Customer Name");
        Console.Write ("> ");
        string customerName = Console.ReadLine();

        Console.WriteLine ("Enter Street Address");
        Console.Write ("> ");
        string customerStreetAddress = Console.ReadLine();

        Console.WriteLine ("Enter City");
        Console.Write ("> ");
        string customerCity = Console.ReadLine();

        Console.WriteLine ("Enter State (ex MD)");
        Console.Write ("> ");
        string customerState = Console.ReadLine();

        Console.WriteLine ("Enter Postal Code");
        Console.Write ("> ");
        string customerPostalCode = Console.ReadLine();
        int postalCode = int.Parse(customerPostalCode);

        Console.WriteLine ("Enter Phone Number");
        Console.Write ("> ");
        string customerPhoneNumber = Console.ReadLine();

        Customer newCustomer = new Customer(){
            Name = customerName,
            Address = customerStreetAddress,
            City = customerCity,
            State = customerState,
            ZipCode = postalCode,
            Phone = customerPhoneNumber
        };

        customerManager.AddCustomer(newCustomer);
    }
  }
}