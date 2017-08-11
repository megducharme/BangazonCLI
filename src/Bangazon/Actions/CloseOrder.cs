using System;
using System.Collections.Generic;
using Bangazon.Models;

namespace Bangazon.Actions
{
  public class CloseOrder
  {
    public static void DoAction(OrderManager orderManager)
    {

        Console.Clear();
        Console.WriteLine ("Choose a payment type");

        List<PaymentType> paymentTypes = orderManager.GetAllPaymentTypes();

        foreach (PaymentType payment in paymentTypes)
        {
            Console.WriteLine($"{payment.Id}. {payment.Name}");
        }

        Console.Write ("> ");
        int chosenPaymentType = int.Parse(Console.ReadLine());
        orderManager.AddPaymentTypeToOrder(chosenPaymentType);

    }
  }
}