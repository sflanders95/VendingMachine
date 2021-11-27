using System;
using System.Collections.Generic;


namespace ConsoleApp1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Vending machine data store: products
            Dictionary<int, Product> products = new Dictionary<int, Product>();

            // Test Data
            products.Add(1, new Product(1.0D, 6, "Salt/Vinegar Chips"));
            products.Add(2, new Product(1.0D, 7, "Plain Chips"));
            products.Add(3, new Product(1.0D, 3, "Doritos"));
            products.Add(4, new Product(1.0D, 6, "Fritos"));
            products.Add(5, new Product(1.0D, 6, "Mentos"));
            products.Add(6, new Product(1.0D, 5, "Pretzels"));

            products.Add(7, new Product(1.0D, 5, "Mint Lifesavers"));
            products.Add(8, new Product(1.0D, 8, "Wintergreen Lifesavers"));
            products.Add(9, new Product(1.0D, 8, "Cherry Lifesavers"));
            products.Add(10, new Product(1.0D, 9, "Hubba Bubba gum"));
            products.Add(11, new Product(2.0D, 5, "Peppermint Altoids"));
            products.Add(12, new Product(2.0D, 6, "Cinnamon Altoids"));

            try
            {
                PrintInventory(products);
            } catch (Exception e)
            {
                Console.WriteLine($"{e}");
            }

            Console.WriteLine("\r\nPress Enter to continue.");
            Console.ReadLine();
        }

        /// <summary>Display each item and it's quantity</summary>
        /// <param name="items">The Collection</param>
        /// <param name="itemsPerRow">Prevents word wrap</param>
        public static void PrintInventory(Dictionary<int, Product> items, int itemsPerRow = 4)
        {
            if (items is null)
                Environment.Exit(1);

            Console.WriteLine("Current Inventory:");
            for (int i = 1; i <= items.Count; i++)
            {
                Console.Write($"{items[i]}");

                if (i % itemsPerRow == 0)
                    Console.WriteLine("");
                else
                    Console.Write("\t");
            }
            
        }

        /// <summary>Each item in a vending machine.</summary>
        public class Product
        {
            /// <summary>ctor to make it easier to create in one line</summary>
            public Product(double cost, int quantity, string name)
            {
                price = cost;
                qty = quantity;
                itemName = name;
            }

            public double price = 0.0D;
            public double qty = 0.0D;
            public string itemName = "";

            public override string ToString()
            {
                return ToString(-20);
            }
            
            /// <remarks>
            /// padding must be a constant. Found a variable formatting workaround from:
            /// https://stackoverflow.com/questions/9542994/variable-string-format-length
            /// </remarks>
            public string ToString(int padding)
            {
                string str = $"{itemName} ({qty})";
                string format = string.Format("{{0,{0}}}", padding);
                return string.Format(format, str);
            }
        }

    }
}
