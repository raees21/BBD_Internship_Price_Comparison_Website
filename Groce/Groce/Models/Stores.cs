using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Groce.Models
{
    public class Stores
    {
        [Key]
        public int StoreID { get; set; }

        public string StoreName { get; set; }
    }
}
