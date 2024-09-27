// LoginController.cs
// basic without auth 

using BookStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace product__app.Controllers
{
    public class RegisterController : Controller
    {
        private BookStoreContext context { get; set; }

        public RegisterController(BookStoreContext ctx)
        {
            context = ctx;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string username, string password, string confirmPassword)
        {
            if (password != confirmPassword)
            {
                ViewBag.Error = "Passwords do not match!";
                return View();
            }
            User user = new User
            {
                Username = username,
                Password = password
            };
            context.Users.Add(user);
            context.SaveChanges();
            return RedirectToAction("Index", "Login");
        }
    }
}

