using Groce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Groce.Controllers;
using System.Net;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

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

        public async Task<IActionResult> Index()
        {
            //GroceriesController gro = new GroceriesController
            //GroceriesController groceriesController = new GroceriesController().GetGroceriesByName("eggs");
            try
            {
                WebClient wc = new WebClient();
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                var somestring = wc.DownloadString("https://localhost:5001/api/groceries/list");
                var vs = JsonConvert.DeserializeObject<IEnumerable<string>>(somestring);
                ViewBag.Groceries = new SelectList(vs);
                var pricer = wc.DownloadString("https://localhost:5001/api/groceries/pricesearch/"+ViewBag.Groceries);
                //  var pry = JsonConvert.DeserializeObject<IEnumerable<GroceryTyper>>(somestring);
                ViewBag.Prices = "HELLo";
                return View();
            }
            catch (WebException we)
            {
                // add some kind of error processing
            }

            return View();
        }
        public void Button_click()
        {
            ViewBag.Prices = "HELLo";
            Console.WriteLine("CLICK");
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
