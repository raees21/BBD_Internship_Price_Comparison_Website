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
            ViewBag.Groceries = new SelectList(search);





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