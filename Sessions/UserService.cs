using BookStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace product__app.Sessions
{
    public class UserService: IUserService
    {

        private BookStoreContext context { get; set; }

        public UserService(BookStoreContext ctx)
        {
            context = ctx;
        }
       
        public User Login(string username, string password)
        {
            return context.Users.SingleOrDefault(u => u.Username == username && u.Password == password);
        }
    }
}
