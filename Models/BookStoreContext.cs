using Microsoft.EntityFrameworkCore;
using Product_app.Models;

namespace BookStore.Models
{
    public class BookStoreContext : DbContext
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        
            modelBuilder.Entity<User>().HasData
                (
                new User
                {
                    UserID = 1,
                    Username = "admin",
                    Password = "admin"
                }
            );
        }
    }
}