using Application.Common.Interfaces;
using Application.Common.Models;
using Application.DTOs;
using MediatR;

namespace Application.Handlers.Queries
{
    public class GetCategoriesQuery : IRequest<Result<IEnumerable<CategoryDto>>>
    {
    }


    public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, Result<IEnumerable<CategoryDto>>>
    {
        private readonly ICategoryService _categoryService;
        public GetCategoriesQueryHandler(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public async Task<Result<IEnumerable<CategoryDto>>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            return await _categoryService.GetAllAsync();
        }
    }
}
