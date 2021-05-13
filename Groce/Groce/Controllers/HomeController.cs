using Groce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using static Models.Functions.Functions;
using Models.Functions;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Groce.Controllers
{
    public class HomeController : Controller
    {

        private readonly GroceryContext _groceryContext;
        private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public HomeController(ILogger<HomeController> logger, GroceryContext groceryContext)
        {
            _groceryContext = groceryContext;
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.Groceries = _groceryContext.Groceries.Find(1).GroceryName;

            //List<string> Groceries = new List<string>();

            //var groceries = new List<Groceries>();
            //for(int i = 1; i < 13; i++)
            //{
            //    groceries.Add(new Groceries() { GroceryName = _groceryContext.Groceries.Find(i).GroceryName.ToString() });
            //}

            //for (int i = 1; i < 13; i++)
            //{
            //Console.WriteLine(_groceryContext.Groceries.Find(i).GroceryName.ToString());
            //}

            //foreach (var j in groceries)
            //{
            //    Console.WriteLine(j);
            //}





            return View();
        }

        [HttpPost]
        public IActionResult Index(Groceries grocery)
        {

            Functions functions = new Functions();
            String name = grocery.GroceryName;

            var groceries = functions.GroceriesList(_groceryContext);
            var prices = groceries.Where(x => x.GroceryName.Trim().ToLower() == name.ToLower()).ToList();
            var index = prices.FindIndex(x => x.GroceryName.Trim().ToLower() == name.ToLower());

            decimal price1 = prices[index].pricing[0].GroceryPrice;
            decimal price2 = prices[index].pricing[1].GroceryPrice;
            decimal price3 = prices[index].pricing[2].GroceryPrice;

            Console.WriteLine(index.ToString());
            ViewData["Price1"] = price1;
            ViewData["Price2"] = price2;
            ViewData["Price3"] = price3;

            ViewData["Name"] = grocery.GroceryName;

            var min = functions.Minimum(price1, price2 , price3);
            var max = functions.Maximum(price1, price2, price3);

            //var list = _groceryContext.Groceries.Find(1).GroceryName;
            
            
            //ViewBag.Groceries = _groceryContext.Pricing.Find(1).GroceryPrice.ToString();
            var search = functions.Search(_groceryContext);
            ViewBag.Groceries = groceries;
            



            ViewData["Prices"] = "";
             ViewData["ID"] = grocery.GroceryID;
             ViewData["Type"] = grocery.GroceryType;
             ViewData["Description"] = grocery.GroceryDescription;
            
            /* create list Shopping and pass to ViewData
             * 
             * var shoppingList = from....
             * 
             * ViewData["Shopping"] = shoppingList;
             */
            

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpPost]
        public IActionResult search(string search)
        {
            ViewData["search_res"] = "We search";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
