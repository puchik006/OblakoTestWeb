using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OblakoTestWeb.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;


namespace OblakoTestWeb.Controllers
{
    public class HomeController : Controller
    {

        ProductsContext db;
        public HomeController(ProductsContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            return View(db.Product.ToList());
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
