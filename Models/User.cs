// user model
using System.ComponentModel.DataAnnotations;



public class User
{   
    public int UserID { get; set; }

    [Required(ErrorMessage = "Username is required")]
    public string Username { get; set; }

    [Required(ErrorMessage = "Password is required")]
    public string Password { get; set; }
}

