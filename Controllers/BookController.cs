using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Product_app.Models;

namespace product_app.Controllers
{
    public class BookController : Controller
    {

        private BookStoreContext context { get; set; }

        public BookController(BookStoreContext ctx)
        {
            context = ctx;
        }
        public IActionResult Detail(int id)
        {
            var book = context.Books.Find(id);
            return View(book);
        }

        [HttpGet]
        public IActionResult List()
        {
            ViewBag.Type = "All";
            var books = context.Books.ToList();
            ViewBag.Users = context.Users.ToList();

            return View(books);
        }

        [HttpGet]
        public IActionResult My()
        {
            var userIdString = HttpContext.Session.GetString("UserId");
            int userId;
            int.TryParse(userIdString, out userId);
            ViewBag.Type = "My";
            var books = context.Books.Where(b => b.UserID == userId).ToList();
            ViewBag.Users = context.Users.ToList();

            return View("List", books);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(string bookName, double bookPrice)
        {
            var userIdString = HttpContext.Session.GetString("UserId");
            int userId;

            if (!int.TryParse(userIdString, out userId))
            {
                // Handle the case where conversion fails, e.g., return an error response
                return BadRequest("Invalid user ID.");
            }

            Book book = new Book
            {
                BookName = bookName,
                BookPrice = (decimal)bookPrice,
                UserID = userId // Assign the converted integer user ID
            };

            context.Books.Add(book);
            context.SaveChanges();

            return RedirectToAction("List", "Book");
        }


        [HttpGet]
        public IActionResult Search(string search, int? authorId)
        {
            var books = context.Books.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                books = books.Where(b => b.BookName.Contains(search));
            }

            if (authorId.HasValue)
            {
                books = books.Where(b => b.UserID == authorId.Value);
            }
            ViewBag.Users = context.Users.ToList();

            return View("List", books.ToList());
        }

    }
}
