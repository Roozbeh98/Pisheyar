using FluentValidation;

namespace Pisheyar.Application.Accounts.Commands.Register
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            //RuleFor(v => v.Title)
            //    .MaximumLength(200)
            //    .NotEmpty();
        }
    }
}
