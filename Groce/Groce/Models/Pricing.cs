using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Groce.Models
{
    public class Pricing
    {
        public int GroceryID { get; set; }
        public int ShopID { get; set; }
        public double GroceryPrice { get; set; }
    }
}
