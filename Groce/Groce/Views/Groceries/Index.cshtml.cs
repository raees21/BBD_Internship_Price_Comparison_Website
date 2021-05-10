using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Groce.Data;
using Groce.Models.Groceries;

namespace Groce.Views.Groceries
{
    public class IndexModel : PageModel
    {
        private readonly Groce.Data.GroceContext _context;

        public IndexModel(Groce.Data.GroceContext context)
        {
            _context = context;
        }

        public IList<Grocery> Grocery { get;set; }

        public async Task OnGetAsync()
        {
            Grocery = await _context.Grocery.ToListAsync();
        }
    }
}
