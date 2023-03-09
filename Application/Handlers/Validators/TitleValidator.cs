using Core.Interfaces;
using FluentValidation;

namespace Application.Handlers.Validators
{
    public class TitleValidator : AbstractValidator<ITitle>
    {
        public TitleValidator()
        {

            RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title is required.")
            .MaximumLength(100).WithMessage("Title must not exceed 100 characters.");
        }
    }
}
