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
    public class DeleteModel : PageModel
    {
        private readonly Groce.Data.GroceContext _context;

        public DeleteModel(Groce.Data.GroceContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Grocery = await _context.Grocery.FindAsync(id);

            if (Grocery != null)
            {
                _context.Grocery.Remove(Grocery);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
