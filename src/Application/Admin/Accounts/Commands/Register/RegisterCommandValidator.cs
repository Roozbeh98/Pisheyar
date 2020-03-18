using FluentValidation;

namespace Pisheyar.Application.Accounts.Commands.Register
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(v => v.Name)
                .MaximumLength(128)
                .NotEmpty();
        }
    }
}
