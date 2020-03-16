using FluentValidation;

namespace Pisheyar.Application.Accounts.Commands.Login
{
    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {

        }
    }
}
