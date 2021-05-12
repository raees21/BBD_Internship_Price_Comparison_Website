using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace Groce.Models { 
    public class GroceryContext : DbContext
    {
        public GroceryContext(
            DbContextOptions<GroceryContext> options)
            : base(options)
        {
        }

        public DbSet<Groce.Models.Groceries> Groceries { get; set; }
        public DbSet<Groce.Models.Pricing> Pricing { get; set; }
    }
}