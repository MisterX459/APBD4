namespace LegacyApp;

public class UserCreation : IUserCreation
{
    private readonly ClientRepository repository;
    private readonly UserCreditService CreditService;

    public UserCreation(ClientRepository clientRepository, UserCreditService userCreditService)
    {
        repository= clientRepository;
        CreditService = userCreditService;
    }

    public bool AddUser(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
    {
        if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || !email.Contains("@") || !email.Contains("."))
        {
            return false;
        }

        var now = DateTime.Now;
        int age = now.Year - dateOfBirth.Year;
        if (now.Month < dateOfBirth.Month || (now.Month == dateOfBirth.Month && now.Day < dateOfBirth.Day)) age--;

        if (age < 21)
        {
            return false;
        }

        var client = repository.GetById(clientId);
        if (client == null)
        {
            return false;
        }

        var user = new User
        {
            Client = client,
            DateOfBirth = dateOfBirth,
            EmailAddress = email,
            FirstName = firstName,
            LastName = lastName
        };

        AdjustCreditLimit(client, user);

        if (user.HasCreditLimit && user.CreditLimit < 500)
        {
            return false;
        }

        UserDataAccess.AddUser(user);
        return true;
    }

    private void AdjustCreditLimit(Client client, User user)
    {
        switch (client.Type)
        {
            case "VeryImportantClient":
                user.HasCreditLimit = false;
                break;
            case "ImportantClient":
                var creditLimit = CreditService.GetCreditLimit(user.LastName, user.DateOfBirth);
                user.CreditLimit = creditLimit * 2;
                break;
            default:
                user.HasCreditLimit = true;
                user.CreditLimit = CreditService.GetCreditLimit(user.LastName, user.DateOfBirth);
                break;
        }
    }
}