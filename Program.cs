using System;
using System.Collections.Generic;
using System.Linq;

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
                Console.WriteLine($"{e.Name}: {e.PriceCalculated}  {(e.Quantity == 1 ? string.Empty : "(" + e.Quantity + " @ " + e.PriceUnitCalculated + ")")} ");

            Console.WriteLine($"Sales Taxes: { groupProducts.Sum(x => x.PriceCalculated) - products.Sum(x => x.Price) }");
            Console.WriteLine($"Total: {groupProducts.Sum(x => x.PriceCalculated)}");
            Console.Read();

            #endregion
        }


        static List<Product> InputElements()
        {
            List<Product> products = new List<Product>();

            do
            {
                Product product = new Product();

                Console.WriteLine();
                Console.Write("Enter product **NAME** : ");

                var name = Console.ReadLine();
                product.Name = char.ToUpper(name[0]).ToString() + name.Trim().Substring(1);
                product.Name = name.Trim();

                Console.Write("Enter product **PRICE** : ");
                product.Price = Convert.ToDecimal(Console.ReadLine());
                product.PriceCalculado = product.Price;

                products.Add(product);

                Console.Write($"\nPress [ENTER] to Add New Product, or [Other key] to Show Totals Invoices,\n");
            } while (Console.ReadKey().Key == ConsoleKey.Enter);


            return products;

        }

    }
}
