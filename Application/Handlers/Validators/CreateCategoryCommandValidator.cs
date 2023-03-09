using Application.Handlers.Commands;
using FluentValidation;

namespace Application.Handlers.Validators
{
    public class CreateCategoryCommandValidator  : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(x => x.Dto.Title)
            .NotEmpty()
            .WithMessage($"Title is required.")
            .MaximumLength(160)
            .WithMessage("Title must not exceed 160 characters.");
        }
    }
}
