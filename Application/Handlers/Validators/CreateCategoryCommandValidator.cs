using Application.Handlers.Commands;
using Core.Interfaces;
using FluentValidation;

namespace Application.Handlers.Validators
{
    public class CreateCategoryCommandValidator  : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(dto => (ITitle)dto.Dto)
                .SetValidator(new TitleValidator());

            RuleFor(dto => (IContent)dto.Dto)
                .SetValidator(new ContentValidator());
        }
    }
}
