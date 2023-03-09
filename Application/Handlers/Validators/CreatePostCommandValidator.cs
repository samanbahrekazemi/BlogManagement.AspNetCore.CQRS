using Application.Handlers.Commands;
using FluentValidation;

namespace Application.Handlers.Validators
{
    public class CreatePostCommandValidator : AbstractValidator<CreatePostCommand>
    {

        public CreatePostCommandValidator()
        {
            RuleFor(x => x.Dto.Title)
            .NotEmpty().WithMessage($"Title is required.")
            .MaximumLength(160).WithMessage("Title must not exceed 160 characters.");

            RuleFor(x => x.Dto.CategoryId)
                .NotEmpty().WithMessage("CategoryId is required.");
        }

    }
}
