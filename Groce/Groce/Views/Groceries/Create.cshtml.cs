using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Groce.Data;
using Groce.Models.Groceries;

namespace Groce.Views.Groceries
{
    public class CreateModel : PageModel
    {
        private readonly Groce.Data.GroceContext _context;

        public CreateModel(Groce.Data.GroceContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Grocery Grocery { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Grocery.Add(Grocery);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
