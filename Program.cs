using System;
using System.Collections.Generic;
using System.Linq;
using Sales_Exercise.Enumeration;

namespace Sales_Exercise
{
    class Program
    {

        static void Main(string[] args)
        {
            #region input list products

            var products = InputElements();

            #endregion

            #region process invoice

            Process process = new Process();
            process.apply_Tax(products);
            var groupProducts = process.groupByProducts(products);

            #endregion

            #region output

            Console.WriteLine("\n\n ******** Output ******** \n");
            foreach (var e in groupProducts)
                Console.WriteLine($"{ CapitalizeText(e.Name)}: {e.PriceCalculated}  {(e.Quantity == 1 ? string.Empty : "(" + e.Quantity + " @ " + e.PriceUnitCalculated + ")")} ");

            Console.WriteLine($"Sales Taxes: { groupProducts.Sum(x => x.PriceCalculated) - products.Sum(x => x.Price) }");
            Console.WriteLine($"Total: {groupProducts.Sum(x => x.PriceCalculated)}");
            Console.Read();

            #endregion
        }

        static void Header()
        {

            Console.WriteLine();
            Console.Write("**SALES TAXES** : ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("To enter CATEGORIES consider the values:");
            Console.WriteLine();

            Console.WriteLine("Others => 0");
            Console.WriteLine("Book => 1");
            Console.WriteLine("Food => 2");
            Console.WriteLine("Medical Products => 3.");
            Console.WriteLine("---------------------------------------------------------------------------------------------");
            Console.WriteLine();
        }

        static List<Product> InputElements()
        {
            List<Product> products = new List<Product>();

            Header();

            do
            {
                Product product = new Product();

                Console.Write("Enter product **NAME** : ");
                var name = Console.ReadLine();
                product.Name = CapitalizeText(name);

                Console.Write("Enter product **PRICE** : ");
                product.Price = Convert.ToDecimal(Console.ReadLine());
                product.PriceCalculado = product.Price;

                Console.Write("Enter ** CATEGORY** : ( Others => 0   |   Book => 1   |   Food => 2   |   Medical Products => 3 ) ");
                var category = Console.ReadLine();
                product.Category = (Enumerations.Categories)(Int32.Parse(category));

                products.Add(product);

                Console.Write($"\nPress [ENTER] to Add New Product, or [Other key] to Show Totals Invoices,\n");
            } while (Console.ReadKey().Key == ConsoleKey.Enter);


            return products;

        }


        static string CapitalizeText(string text)
        {
            text = char.ToUpper(text[0]).ToString() + text.Trim().Substring(1);
            return text;
        }


    }
}
