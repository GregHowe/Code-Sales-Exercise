using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales_Exercise.Enumeration
{
    public class Enumerations
    {
        public enum Categories
        {
            Otros =0,
            Books = 1,
            Food = 2,
            MedicalProducts = 3
        }

        public static List<Categories> CategoryListExcept()
        {
            return new List<Categories>
            {
               Categories.Books,
               Categories.Food,
               Categories.MedicalProducts
            };
        }

    }
}
