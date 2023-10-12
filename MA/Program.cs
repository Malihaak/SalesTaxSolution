using SalesTax;
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Store!");
        List<Item> shoppingBasket = new List<Item>();

        while (true)
        {
            Console.Write("Enter item name (or 'done' to finish shopping): ");
            string itemName = Console.ReadLine();
            if (itemName.ToLower() == "done")
                break;

            Console.Write("Enter item price: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal itemPrice))
            {
                Console.Write("Is the item imported? (yes/no): ");
                bool isImported = Console.ReadLine().ToLower() == "yes";

                Console.Write("Is the item exempt from basic sales tax? (yes/no): ");
                bool isExempt = Console.ReadLine().ToLower() == "yes";

                shoppingBasket.Add(new Item(itemName, itemPrice, isImported, isExempt));
            }
            else
            {
                Console.WriteLine("Invalid price. Please enter a valid number.");
            }
        }

        Console.WriteLine("Receipt:");
        foreach (var item in shoppingBasket)
        {
            Console.WriteLine($"{item.Name}: {item.GetTotalPrice():F2}");
        }

        Console.WriteLine($"Sales Taxes: {shoppingBasket.Sum(item => item.GetSalesTax()):F2}");
        Console.WriteLine($"Total: {shoppingBasket.Sum(item => item.GetTotalPrice()):F2}");
    }
    
}

