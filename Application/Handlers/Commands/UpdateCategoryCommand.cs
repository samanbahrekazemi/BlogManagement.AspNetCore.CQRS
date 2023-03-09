using Application.Common.Interfaces;
using Application.Common.Models;
using Application.DTOs;
using MediatR;

namespace Application.Handlers.Commands
{
    public class UpdateCategoryCommand : IRequest<Result<CategoryDto>>
    {
        public int Id { get; set; }
        public UpdateCategoryDto Category { get; set; }

        public UpdateCategoryCommand(int id, UpdateCategoryDto category)
        {
            Id = id;
            Category = category;
        }
    }


    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, Result<CategoryDto>>
    {
        private readonly ICategoryService _categoryService;

        public UpdateCategoryCommandHandler(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<Result<CategoryDto>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            return await _categoryService.UpdateAsync(request.Id, request.Category);
        }
    }
}
