using System.ComponentModel.DataAnnotations;

namespace Product_app.Models
{
    public class Book
    {
        public int BookID { get; set; }
        [Required(ErrorMessage = "Please enter a book name")]
        public string BookName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please enter a book price")]
        public decimal BookPrice { get; set; }

        // userid
        public int UserID { get; set; }
    }
}
