using Application.Common.Interfaces;
using Application.Common.Models;
using Application.DTOs;
using MediatR;

namespace Application.Handlers.Commands
{
    public class CreateCategoryCommand : IRequest<Result<CategoryDto>>
    {
        public CreateCategoryCommand(CreateCategoryDto categoryDto)
        {
            CategoryDto = categoryDto;
        }
        public CreateCategoryDto CategoryDto { get; set; }
    }



    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Result<CategoryDto>>
    {
        private readonly ICategoryService _categoryService;

        public CreateCategoryCommandHandler(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<Result<CategoryDto>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            return await _categoryService.CreateAsync(request.CategoryDto);
        }
    }
}
