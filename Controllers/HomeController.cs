using BookStore.Models;
using Microsoft.AspNetCore.Mvc;

using System.Diagnostics;

namespace product__app.Controllers //    /Home/Privacy
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
