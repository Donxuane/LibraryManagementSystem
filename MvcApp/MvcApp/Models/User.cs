namespace MvcApp.Models;

public class User
{
    public string? UserName { get; set; }
    public string? UserPassword { get; set; }

    public static readonly List<User> user = [
    new User{UserName = "admin", UserPassword = "admin123"},
        new User{UserName = "userAdmin", UserPassword = "adminAdmin"}
    ];
}
