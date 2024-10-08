
using FluentValidation;

namespace Application.Features.Categories.Commands.Create
{
    public class CreateCategoryCommandValidator: AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("{PropertyName} is required.");
        }
    }
}