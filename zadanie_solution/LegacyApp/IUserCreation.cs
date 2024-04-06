namespace LegacyApp;

public interface IUserCreation
{
    bool AddUser(String FirstName, string LastName, string email, DateTime BirthDate,
        int Id);
}