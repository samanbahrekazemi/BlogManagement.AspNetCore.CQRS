using Application.Common.Mapping;
using Core.Models;

namespace Application.DTOs
{
    public class PostDto : IMapFrom<Post>
    {

        public PostDto()
        {
            PostTags = new List<PostTag>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public bool IsPublished { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public List<PostTag> PostTags { get; set; } 
    }
}
