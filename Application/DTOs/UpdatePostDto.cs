using Application.Common.Mapping;
using Core.Models;

namespace Application.DTOs
{
    public class UpdatePostDto : IMapFrom<Post> , IMapFrom<PostDto>
    {
        public int Id { get; set; }
        public string Title { get; set; } 
        public string? Content { get; set; }
        public bool IsPublished { get; set; }
        public int CategoryId { get; set; }

        public List<PostTag> PostTags { get; set; }

    }
}
