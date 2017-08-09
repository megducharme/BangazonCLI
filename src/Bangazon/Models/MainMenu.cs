using System;

namespace Bangazon
{
  public class MainMenu
  {
    public int Show()
    {
      Console.Clear();
      Console.WriteLine ("*********************************************************");
      Console.WriteLine ("**  Welcome to Bangazon! Command Line Ordering System  **");
      Console.WriteLine ("*********************************************************");
      Console.WriteLine ("1. Create a customer account");
      Console.WriteLine ("2. Choose active customer");
      Console.WriteLine ("3. Create a payment option");
      Console.WriteLine ("4. Add product to shopping cart");
      Console.WriteLine ("5. Complete an order");
      Console.WriteLine ("6. See product popularity");
      Console.WriteLine ("7. Leave Bangazon!");
			Console.Write ("> ");
      ConsoleKeyInfo enteredKey = Console.ReadKey();
      Console.WriteLine("");
      return int.Parse(enteredKey.KeyChar.ToString());
    }
  }
}