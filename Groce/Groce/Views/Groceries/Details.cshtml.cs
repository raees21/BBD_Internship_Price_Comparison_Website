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
    public class DetailsModel : PageModel
    {
        private readonly Groce.Data.GroceContext _context;

        public DetailsModel(Groce.Data.GroceContext context)
        {
            _context = context;
        }

        public Grocery Grocery { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Grocery = await _context.Grocery.FirstOrDefaultAsync(m => m.Id == id);

            if (Grocery == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
