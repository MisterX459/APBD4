namespace LegacyApp.Tests;
public class UserCreationTest
{
    [Fact]
    public void AddUser_IsFalseWhenFirstNameIsEmptry()
    {
        var userService = new UserService();
        var res = userService.AddUser(null, "Doe", "amogus@gmail.com", DateTime.Parse("2012-12-12"), 1);
        Assert.False(res);

    }
} 