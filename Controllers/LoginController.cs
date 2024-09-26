// LoginController.cs
// basic without auth 

using Microsoft.AspNetCore.Mvc;

namespace product__app.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

