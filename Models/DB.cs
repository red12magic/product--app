using Product_app.Models;

namespace product_app.Models

{
    public class DB
    {
        public static List<Book> GetBooks()
        {
            List<Book> books = new List<Book>
            {
                new Book
                {
                   BookID = 1,
                   BookName = "Rich Dad Poor Dad",
                   BookPrice = (decimal)69
                },
                new Book
                {
                   BookID = 2,
                   BookName = "The 7 Habits of Highly Effective People",
                   BookPrice  = (decimal)11
                },
                new Book
                {
                     BookID = 3,
                     BookName  = "Atomic Habits",
                    BookPrice  = (decimal)25
                },
                new Book
                {
                    BookID = 4,
                   BookName = "Introduction by Ibn Khaldun",
                   BookPrice = (decimal)13
                },
                new Book
                {
                     BookID = 5,
                   BookName = "Psychological complex is your eternal prison",
                    BookPrice = (decimal)29.00
                },
                new Book
                {
                     BookID  = 6,
                    BookName = "The power of habits",
                   BookPrice = (decimal)14.00
                },
                new Book
                {
                    BookID = 7,
                     BookName = "Laws",
                   BookPrice = (decimal)19.99
                },
               
               
            };
            return books;
        }

        public static Book GetBook(int id)
        {
            List<Book> books = DB.GetBooks();
            foreach (Book p in books)
            {
                if (p.BookID == id)
                {
                    return p;
                }
            }
            return new Book(); // return empty Product if not in list
        }
    }
}
