using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Groce.Models
{
    public class Stores
    {
        public string StoreName { get; set; }
        [Key]
        public int StoreID { get; set; }
    }
}
