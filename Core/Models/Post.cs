using Core.Common;
using Core.Interfaces;

namespace Core.Models
{
    public class Post : EntityBase<int>, IAuditableEntity
    {
        public string Title { get; set; } 
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }

        public bool IsPublished { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<PostTag> PostTags { get; set; } = new List<PostTag>();
    }
}
