namespace product__app.Sessions
{
    public interface IUserService
    {


        public User Login(string username, string password);
    }
}
