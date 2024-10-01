// LoginController.cs
// basic without auth 

using Microsoft.AspNetCore.Mvc;
using product__app.Sessions;

namespace product__app.Controllers
{
    public class LoginController : Controller
    {
        private IUserService _userService;

        public LoginController(IUserService userService)
        {
            _userService = userService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string username, string password)
        {
            var user = _userService.Login(username, password);
            if (user != null)
            {

                HttpContext.Session.SetInt32("UserId", user.UserID);
                return RedirectToAction("List", "Book");
            }
            else
            {
                
                ViewBag.Error = "Invalid username or password";
                ViewBag.User = user;
                return View();
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Login");
        }
    }
}

