using BookStore.Models;
using Microsoft.AspNetCore.Mvc;

using System.Diagnostics;

namespace product__app.Controllers
{
    public class HomeController : Controller
    {
      
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        
    }
}
