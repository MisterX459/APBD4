using System.Data;

namespace LegacyApp.Tests;

public class UserServiceTest
{
    [Fact]
    public void AddUser_IsFalseWhenFirstNameIsEmptry()
    {
        var userService = new UserService();
        var res = userService.AddUser(null, "Doe", "amogus@gmail.com", DateTime.Parse("2012-12-12"), 1);
        Assert.False(res);
    }
    [Fact]
    public void AddUser_ExceptionIfClientNotExists()
    {
        var userService = new UserService();
        Action action = () => userService.AddUser("John", "Doe", "amogus@gmail.com", DateTime.Parse("2012-12-12"), 10);
        Assert.Throws<ArgumentException>(action);
    }
}