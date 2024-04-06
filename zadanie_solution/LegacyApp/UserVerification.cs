namespace LegacyApp;

public class UserVerification : IUserVerification
{
    private readonly ClientRepository Repository;

    public UserVerification(ClientRepository repository)
    {
        Repository = repository;
    }
    public bool DataVerification(string FirstName, string LastName, string Email)
    {
        if (string.IsNullOrEmpty(FirstName) || string.IsNullOrEmpty(LastName))
        {
            return false;
        }

        if (!Email.Contains("@") || !Email.Contains("."))
        {
            return false;
        }

        return true;
    }

    public bool AgeVerification(DateTime dateOfBirth)
    {
        var now = DateTime.Now;
        int age = now.Year - dateOfBirth.Year;

        if (now.Month < dateOfBirth.Month || (now.Month == dateOfBirth.Month && now.Day < dateOfBirth.Day))
        {
            age--;
        }

        return age >= 21;
    }

    public bool ClientTypeVerification(int clientId, out Client client)
    {
        client = Repository.GetById(clientId);

        return client != null;
    }
}