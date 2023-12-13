using FluentValidation;

namespace Item_Templates.Login;

/// <summary>
/// Dependencies
///  - Radzen
///  - Fontawesome
///  - FluentValidation
/// </summary>
public partial class LoginView
{
    private RegisterModel _registerModel = new();
    private LoginModel _loginModel = new();

    private bool _singUpView;

    private Task Login(LoginModel registerModel)
    {
        try
        {
        }
        catch (Exception)
        {
            // ignored
        }
        throw new NotImplementedException();
    }

    private Task Register(RegisterModel loginModel)
    {
        try
        {
        }
        catch (Exception)
        {
            // ignored
        }
        throw new NotImplementedException();
    }

    private void ToggleView()
    {
        _singUpView = !_singUpView;
        _loginModel = new ();
        _registerModel = new ();
    }

    public class RegisterModel
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }

    public class LoginModel
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }

    public class LoginValidator : AbstractValidator<LoginModel>
    {
        public LoginValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email can't be empty.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password can't be empty.");
        }
    }

    public class RegisterValidator : AbstractValidator<RegisterModel>
    {
        public RegisterValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name can't be empty.");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email can't be empty."); 
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password can't be empty."); 
        }
    }
}