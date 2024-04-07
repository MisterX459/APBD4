using System;

namespace LegacyApp;

public interface IUserService
{
    bool AddUser(string FirstName, string LastName, string Email, DateTime BirthDate, int Id);
}