namespace LegacyApp;

public interface IUserVerification
{
    bool AgeVerification(DateTime BirthDate);
    bool DataVerification(string FirstName, string LastName, string Email);
    bool ClientTypeVerification(int ID, out Client client);
}