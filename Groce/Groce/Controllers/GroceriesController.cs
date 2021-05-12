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
            var groceries = await _context.Groceries.Where(x => x.GroceryName.ToLower() == name.ToLower()).ToListAsync();

            if (groceries == null)
            {
                return NotFound();
            }

            return groceries;
        }

        // GET: api/Groceries/pricesearch
        [HttpGet("pricesearch/{name}")]
        public async Task<ActionResult<GroceryTyper>> GetGroceriesByName(string name)
        {
            var item = await _context.Groceries.Where(x => x.GroceryName.ToLower() == name.ToLower()).ToListAsync();
            if (item.Count == 0)
            {
                return NotFound();  
            }
            int id = item[0].GroceryID;
            var list = await _context.Pricing.Where(x => x.GroceryID == id).ToListAsync();

            GroceryTyper groce = new GroceryTyper();
            groce.grocery = item[0];
            groce.pricings = list;

            Console.WriteLine(groce);

            if (groce == null)
            {
                return NotFound();
            }

            return groce;
        }

        // GET: api/Groceries/pricesearcheapest
        [HttpGet("pricesearchcheapest/{name}")]
        public async Task<ActionResult<GroceryTyper>> GetGroceriesByNameCheap(string name)
        {
            var item = await _context.Groceries.Where(x => x.GroceryName.ToLower() == name.ToLower()).ToListAsync();
            if (item.Count == 0)
            {
                return NotFound();
            }
            int id = item[0].GroceryID;
            var list = await _context.Pricing.Where(x => x.GroceryID == id).ToListAsync();

            GroceryTyper groce = new GroceryTyper();
            groce.grocery = item[0];
            groce.pricings = (IEnumerable<Pricing>)list.OrderByDescending(i => i.GroceryPrice).First();

            if (groce == null)
            {
                return NotFound();
            }

            return groce;
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

        // GET: api/Groceries/full/5
        [HttpGet("full/{id}")]
        public async Task<ActionResult<GroceryTyper>> GetGroceriesFullPricing(int id)
        {
            var groceries = await _context.Groceries.FindAsync(id);
            var list = await _context.Pricing.Where(x => x.GroceryID == id).ToListAsync();

            GroceryTyper groce = new GroceryTyper();
            groce.grocery = groceries;
            groce.pricings = list;

            if (groce == null)
            {
                return NotFound();
            }

            return groce;
        }

        // GET: api/Groceries/price/5
        [HttpGet("price/{id}")]
        public async Task<ActionResult<IEnumerable<Pricing>>> GetPricings(int id)
        {
            var pricings = await _context.Pricing.Where(x => x.GroceryID == id).ToListAsync();

            if (pricings == null)
            {
                return NotFound();
            }

            return pricings;
            // var groceries = await _context.Groceries.FindAsync(id);

            // if (groceries == null)
            //  {
            //     return NotFound();
            //  }

            // return groceries;
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
