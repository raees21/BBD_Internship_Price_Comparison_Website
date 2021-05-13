using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Groce.Models
{
    public class Pricing
    {
        [Key]
        public int PricingID { get; set; }
        public int GroceryID { get; set; }
        public int StoreID { get; set; }
        public decimal GroceryPrice { get; set; }
    }
}
