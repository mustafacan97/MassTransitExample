namespace IdentityService.UseCases.Commands.Register;

public class RegisterCommand : ICommand<RegisterCommandResponse>
{
    #region Constructors and Destructors

    public RegisterCommand(string email, string password)
    {
        Email = email;
        Password = password;
    }

    #endregion

    #region Public Properties

    public string Email { get; private set; } = string.Empty;

    public string Password { get; private set; } = string.Empty;

    #endregion
}