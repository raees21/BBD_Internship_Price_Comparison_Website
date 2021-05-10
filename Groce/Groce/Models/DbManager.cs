using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace RazorPagesMovie.Data
{
    public class GroceryContext : DbContext
    {
        public GroceryContext(
            DbContextOptions<GroceryContext> options)
            : base(options)
        {
        }

        public DbSet<Groce.Models.Class> Groceries { get; set; }
    }
}
