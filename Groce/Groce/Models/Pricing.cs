using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Groce.Models
{
    public class Pricing
    {
       
        public decimal GroceryPrice { get; set; }
        [ForeignKey("Store")]
        public int StoreID { get; set; }
        [ForeignKey("Grocery")]
        public int GroceryID { get; set; }
        [Key]
        public int PricingID { get; set; }
    }
}
