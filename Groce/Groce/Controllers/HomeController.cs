using Groce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
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

            Functions functions = new Functions();
            var groceries = functions.GroceriesList(_groceryContext);
            //ViewBag.Groceries = _groceryContext.Pricing.Find(1).GroceryPrice.ToString();
            Console.WriteLine($"Juast... {groceries.Count()}");
            var search = functions.Search(_groceryContext);
            ViewBag.Groceries = search[2];
            //var search = functions.Search(_groceryContext);
            //Viewbag.Groceries = new SelectList(search);


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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
