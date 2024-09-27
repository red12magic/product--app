using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Product_app.Models;

namespace product_app.Controllers {
    [SessionAuthorization]
    public class UserController : Controller {

        private BookStoreContext context { get; set; }

        public UserController(BookStoreContext ctx) {
            context = ctx;
        }

        [HttpGet]
        public IActionResult Detail(int id) {
            var user = context.Users.Find(id);
            return View(user);
        }

        public IActionResult ChangePassword(int id) {
            var user = context.Users.Find(id);
            return View(user);
        }
       

    }
}
