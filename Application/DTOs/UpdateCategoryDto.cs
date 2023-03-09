using Application.Common.Mapping;
using Core.Models;

namespace Application.DTOs
{
    public class UpdateCategoryDto : IMapFrom<Category>, IMapFrom<CategoryDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Content { get; set; }
    }
}
