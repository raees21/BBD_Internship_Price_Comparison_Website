using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Groce.Models;

namespace Groce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroceriesController : ControllerBase
    {
        private readonly GroceryContext _context;

        public GroceriesController(GroceryContext context)
        {
            _context = context;
        }

        // GET: api/Groceries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Groceries>>> GetGroceries()
        {
            return await _context.Groceries.ToListAsync();
        }

        // GET: api/Groceries/list
        [HttpGet("list")]
        public async Task<ActionResult<IEnumerable<String>>> GetGroceriesList()
        {
            return await _context.Groceries.Select(a => a.GroceryName).ToListAsync();
            //  var returner = from item in list
            //               select item.GroceryName;
            //var names = list.Select(a => a.GroceryName);
            // return await list.ToListAsync();
        }

        // GET: api/Groceries/list
        [HttpGet("list/{name}")]
        public async Task<ActionResult<IEnumerable<Groceries>>> GetGroceriesListFind(string name)
        {
            var groceries = await _context.Groceries.Where(x => x.GroceryName == name).ToListAsync();

            if (groceries == null)
            {
                return NotFound();
            }

            return groceries;
        }

        // GET: api/Groceries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Groceries>> GetGroceries(int id)
        {
            var groceries = await _context.Groceries.FindAsync(id);

            if (groceries == null)
            {
                return NotFound();
            }

            return groceries;
        }

        // PUT: api/Groceries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGroceries(int id, Groceries groceries)
        {
            if (id != groceries.GroceryID)
            {
                return BadRequest();
            }

            _context.Entry(groceries).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroceriesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Groceries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Groceries>> PostGroceries(Groceries groceries)
        {
            _context.Groceries.Add(groceries);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGroceries", new { id = groceries.GroceryID }, groceries);
        }

        // DELETE: api/Groceries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroceries(int id)
        {
            var groceries = await _context.Groceries.FindAsync(id);
            if (groceries == null)
            {
                return NotFound();
            }

            _context.Groceries.Remove(groceries);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GroceriesExists(int id)
        {
            return _context.Groceries.Any(e => e.GroceryID == id);
        }
    }
}
