// LoginController.cs
// basic without auth 

using Microsoft.AspNetCore.Mvc;

namespace product__app.Controllers
{
    public class RegisterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

