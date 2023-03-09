using Application.Common.Mapping;
using Core.Models;

namespace Application.DTOs
{
    public class UpdateCategoryDto : IMapFrom<Category>, IMapFrom<CategoryDto>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Content { get; set; }
    }
}
