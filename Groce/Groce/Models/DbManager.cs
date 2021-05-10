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

        public DbSet<Groce.Models.Grocery> Groceries{ get; set; }
    }
}