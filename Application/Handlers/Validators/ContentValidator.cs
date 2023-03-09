using Core.Interfaces;
using FluentValidation;

namespace Application.Handlers.Validators
{
    public class ContentValidator : AbstractValidator<IContent>
    {
        public ContentValidator()
        {
            RuleFor(x => x.Content)
                .MaximumLength(5000).WithMessage("Content must not exceed 5000 characters.");
        }
    }
}
