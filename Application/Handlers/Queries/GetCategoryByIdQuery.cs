using Application.Common.Interfaces;
using Application.Common.Models;
using Application.DTOs;
using MediatR;

namespace Application.Handlers.Queries
{
    public class GetCategoryByIdQuery : IRequest<Result<CategoryDto?>>
    {
        public GetCategoryByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }


    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, Result<CategoryDto?>>
    {
        private readonly ICategoryService _categoryService;

        public GetCategoryByIdQueryHandler(ICategoryService postService)
        {
            _categoryService = postService;
        }

        public async Task<Result<CategoryDto?>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            return await _categoryService.GetByIdAsync(request.Id);
        }
    }
}
