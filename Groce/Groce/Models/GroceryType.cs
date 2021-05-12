using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Groce.Models
{
    public class GroceryType
    {
        public int GroceryID { get; set; }
        public string GroceryName { get; set; }
        public string GroceryDescription { get; set; }

        public List<Pricing> pricing;
    }
}
