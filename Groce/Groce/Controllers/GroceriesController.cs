//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using Groce.Data;
//using Groce.Models.Groceries;

//namespace Groce.Controllers
//{
//    public class GroceriesController : Controller
//    {
//        private readonly GroceContext _context;

//        public GroceriesController(GroceContext context)
//        {
//            _context = context;
//        }

//        // GET: Groceries
//        public async Task<IActionResult> Index()
//        {
//            return View(await _context.Grocery.ToListAsync());
//        }

//        // GET: Groceries/Details/5
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var grocery = await _context.Grocery
//                .FirstOrDefaultAsync(m => m.Id == id);
//            if (grocery == null)
//            {
//                return NotFound();
//            }

//            return View(grocery);
//        }

//        // GET: Groceries/Create
//        public IActionResult Create()
//        {
//            return View();
//        }

//        // POST: Groceries/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("Id,Name,Description,Type,Shop,Price")] Grocery grocery)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Add(grocery);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            return View(grocery);
//        }

//        // GET: Groceries/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var grocery = await _context.Grocery.FindAsync(id);
//            if (grocery == null)
//            {
//                return NotFound();
//            }
//            return View(grocery);
//        }

//        // POST: Groceries/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Type,Shop,Price")] Grocery grocery)
//        {
//            if (id != grocery.Id)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(grocery);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!GroceryExists(grocery.Id))
//                    {
//                        return NotFound();
//                    }
//                    else
//                    {
//                        throw;
//                    }
//                }
//                return RedirectToAction(nameof(Index));
//            }
//            return View(grocery);
//        }

//        // GET: Groceries/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var grocery = await _context.Grocery
//                .FirstOrDefaultAsync(m => m.Id == id);
//            if (grocery == null)
//            {
//                return NotFound();
//            }

//            return View(grocery);
//        }

//        // POST: Groceries/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            var grocery = await _context.Grocery.FindAsync(id);
//            _context.Grocery.Remove(grocery);
//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool GroceryExists(int id)
//        {
//            return _context.Grocery.Any(e => e.Id == id);
//        }
//    }
//}
