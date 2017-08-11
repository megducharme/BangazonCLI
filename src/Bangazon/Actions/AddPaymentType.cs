using System;
using System.Collections.Generic;
using Bangazon.Models;

namespace Bangazon.Actions
{
  public class AddPaymentType
  {
    public static void DoAction(CustomerManager customerManager)
    {

        Console.Clear();
        Console.WriteLine ("Enter Payment Type Name (ex. Visa)");
        Console.Write ("> ");
        string paymentTypeName = Console.ReadLine();

        Console.WriteLine ("Enter Account Number");
        Console.Write ("> ");
        int paymentTypeAccountNumber = int.Parse(Console.ReadLine());

        PaymentType newPaymentType = new PaymentType(){
            Name = paymentTypeName,
            AccountNumber = paymentTypeAccountNumber,
            CustomerId = CustomerManager.activeCustomer.Id
        };

        customerManager.AddNewPaymentType(newPaymentType);
    }
  }
}