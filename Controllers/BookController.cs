using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Product_app.Models;

namespace product_app.Controllers
{
    public class BookController : Controller // 
    {

        private BookStoreContext context { get; set; }

        public BookController(BookStoreContext ctx)
        {
            context = ctx;
        }
        public IActionResult Detail(int id)
        {
            var book = context.Books.SingleOrDefault(b => b.BookID == id);
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
            var userId = HttpContext.Session.GetInt32("UserId");
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
            int userId = HttpContext.Session.GetInt32("UserId")?? 1;
            
            Book book = new Book
            {
                BookName = bookName,
                BookPrice = (decimal)bookPrice,
                UserID = userId 
            };
            //important after every post
            context.Books.Add(book);
            context.SaveChanges();
                                   // action // controller
            return RedirectToAction("List", "Book");
        }
                                                                    //x= 0 

        [HttpGet]
        public IActionResult Search(string search, int? authorId)
        {
            var books = context.Books.AsQueryable();

            if(search != null)
                books = books.Where(b => b.BookName.Contains(search));

            if (authorId != null)
            {
                books = books.Where(b => b.UserID == authorId.Value);
            }
            ViewBag.Users = context.Users.ToList();
                        
            return View("List", books.ToList());
        }
       

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var book = context.Books.Find(id);
            return View(book);
        }

        [HttpPost]
        public IActionResult Edit(Book B1)
        {                
                context.Books.Update(B1);
                context.SaveChanges();
                return RedirectToAction("List", "Book");
        }

        [HttpGet]
        public IActionResult Delete(int id) {
            var book = context.Books.Find(id);
            return View(book);
        }

        [HttpPost]
        public IActionResult Delete(Book book)
        {
            if(book != null) 
            {
            context.Books.Remove(book);
            context.SaveChanges();
            }
            return RedirectToAction("List", "Book");
        }

    }
}
