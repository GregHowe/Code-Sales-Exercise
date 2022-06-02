using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sales_Exercise.Enumeration;

namespace Sales_Exercise
{
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal PriceCalculado { get; set; }
        public Enumerations.Categories Category { get; set; }


    }

}
