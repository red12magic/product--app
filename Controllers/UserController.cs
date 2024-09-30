using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Product_app.Models;

namespace product_app.Controllers {
    public class UserController : Controller {

        private BookStoreContext context { get; set; }

        public UserController(BookStoreContext ctx) {
            context = ctx;
        }

        [HttpGet]
        public IActionResult Details(int id) {
            var user = context.Users.Find(id);
            ViewBag.books=context.Books.ToList();//to get all books and convert them to list
            return View(user);
        }

        public IActionResult ChangePassword() {
            
            return View();
        }
        [HttpPost]

        public IActionResult ChangePassword(string oldpassword,string newpassword)
        {
            var userIdString = HttpContext.Session.GetString("UserId");
            int userId;


            if (!int.TryParse(userIdString, out userId))
            {

                return BadRequest("Invalid user ID.");//
            }

        User user=context.Users.Find(userId);
            if (user.Password== oldpassword)
            {
                user.Password = newpassword;
                context.SaveChanges();
            }
            return View();
        }


    }
}
