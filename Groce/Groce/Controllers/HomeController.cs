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
        private Functions functions = new Functions();


        public HomeController(ILogger<HomeController> logger, GroceryContext groceryContext)
        {
            _groceryContext = groceryContext;
            _logger = logger;
        }


        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Index(Groceries grocery)
        {

            if (string.IsNullOrEmpty(grocery.GroceryName))
            {
                return View();
            }

            Functions functions = new Functions();
            String name = grocery.GroceryName;

            String name = grocery.GroceryName;


            var groceries = functions.GroceriesList(_groceryContext);
            if (groceries.All(x => x.GroceryName.Trim().ToLower() != name.ToLower()))
            {
                return View();
            }

            var products = groceries.Where(x => x.GroceryName.Trim().ToLower() == name.ToLower()).ToList();
            var index = products.FindIndex(x => x.GroceryName.Trim().ToLower() == name.ToLower());

            decimal price1 = products[index].pricing[0].GroceryPrice;
            decimal price2 = products[index].pricing[1].GroceryPrice;
            decimal price3 = products[index].pricing[2].GroceryPrice;

            ViewData["Name"] = grocery.GroceryName;

            ViewData["Price1"] = price1;
            ViewData["Price2"] = price2;
            ViewData["Price3"] = price3;
            ViewData["Description"] = products[index].GroceryDescription;
            ViewData["ID"] = products[index].GroceryID;

            ViewData["Min"] = functions.Maximum(price1, price2, price3);
            ViewData["Max"] = functions.Minimum(price1, price2, price3);

            Functions.AddItems(new List<Object>()
                                        { name, functions.Minimum(price1, price2, price3),
                                          products[index].GroceryDescription});

            ViewBag.Prices = new List<decimal>() { price1, price2, price3 };
            ViewBag.ShoppingListItems = Functions.ShoppingList;

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
