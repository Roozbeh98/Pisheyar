using FluentValidation;

namespace Pisheyar.Application.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(v => v.Name)
                .MaximumLength(128)
                .NotEmpty();
        }
    }
}
