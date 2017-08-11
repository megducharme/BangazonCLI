using System;
using System.Collections.Generic;
using Bangazon.Models;

namespace Bangazon.Actions
{
  public class AddProductToCart
  {
    public static void DoAction(OrderManager orderManager)
    {

        Console.Clear();
        Console.WriteLine ("What do you want to buy?!");

        List<Product> products = orderManager.GetAllProducts();

        foreach (Product product in products)
        {
            Console.WriteLine($"{product.Id}. {product.Name} - ${product.Price}.00");
        }

        Console.Write ("> ");
        int productToBuy = int.Parse(Console.ReadLine());
        orderManager.AddProductToOrder(productToBuy);

    }
  }
}