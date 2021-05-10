using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Groce.Models.Groceries;

namespace Groce.Data
{
    public class GroceContext : DbContext
    {
        public GroceContext (DbContextOptions<GroceContext> options)
            : base(options)
        {
        }

        public DbSet<Groce.Models.Groceries.Grocery> Grocery { get; set; }
    }
}
