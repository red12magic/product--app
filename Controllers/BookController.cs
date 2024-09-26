using Microsoft.AspNetCore.Mvc;
using product_app.Models;
using Product_app.Models;

namespace product_app.Controllers
{
    public class BookController : Controller
    {
        public IActionResult Detail(int id)
        {
            Book book = DB.GetBook(id);
            return View(book);
        }

        public IActionResult List()
        {
            List<Book> books = DB.GetBooks();
            return View(books);
        }
    }
}
