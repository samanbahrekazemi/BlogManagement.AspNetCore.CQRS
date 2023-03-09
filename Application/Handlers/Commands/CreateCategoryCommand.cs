using Application.Common.Interfaces;
using Application.Common.Models;
using Application.DTOs;
using Application.Handlers.Validators;
using MediatR;

namespace Application.Handlers.Commands
{
    public class CreateCategoryCommand : IRequest<Result<CategoryDto>>
    {
        public CreateCategoryCommand(CreateCategoryDto categoryDto)
        {
            Dto = categoryDto;
        }
        public CreateCategoryDto Dto { get; set; }
    }



    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Result<CategoryDto>>
    {
        private readonly ICategoryService _categoryService;
        private readonly CreateCategoryCommandValidator _validator;

        public CreateCategoryCommandHandler(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<Result<CategoryDto>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
                return Result<CategoryDto>.Failure(validationResult.Errors.FirstOrDefault()?.ErrorMessage ?? "");

            return await _categoryService.CreateAsync(request.Dto);
        }
    }
}
