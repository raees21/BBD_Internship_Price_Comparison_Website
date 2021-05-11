using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Groce.Models
{
    public class Groceries
    {
        [Key]
        public int GroceryID { get; set; }
        public string GroceryName { get; set; }
        public string GroceryType { get; set; }
        public string GroceryDescription { get; set; }

    }
}