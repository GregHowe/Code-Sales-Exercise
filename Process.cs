using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales_Exercise
{
    public class Process
    {

        public List<Product> apply_Tax(List<Product> products)
        {
            apply_Tax_BasicSales(products);
            apply_Tax_Import(products);

            return products;
        }

        void apply_Tax_BasicSales(List<Product> products)
        {
            List<string> except10Percent = new List<string>() { "book", "chocolate", "pills" };

            foreach (var p in products)
            {
                var except = false;

                except = except10Percent.Where(x => p.Name.ToLower().Contains(x)).Any();

                if (!except) p.PriceCalculado += Math.Round(p.Price * 0.1m, 2);
            }
        }

        void apply_Tax_Import(List<Product> products)
        {
            foreach (var p in products)
            {
                p.PriceCalculado = (p.Name.Contains("Imported") ? p.PriceCalculado + Math.Round(p.Price * 0.05m, 1) : p.PriceCalculado);
            }
        }

        public List<ProductCalculated> groupByProducts(List<Product> products)
        {
            var groupProducts = products
                                               .GroupBy(u => new { u.Name, u.PriceCalculado, u.Price })
                                               .Select(g => new ProductCalculated
                                               {
                                                   Name = g.Key.Name,
                                                   PriceUnitCalculated = g.Key.PriceCalculado,
                                                   Quantity = g.Count(),
                                                   PriceCalculated = g.Sum(s => s.PriceCalculado),
                                                   PriceOrigin = g.Key.Price
                                               }).ToList();

            return groupProducts;
        }


    }
}
