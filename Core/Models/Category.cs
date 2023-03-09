using Core.Common;
using Core.Interfaces;

namespace Core.Models
{
    public class Category : EntityBase<int>, IAuditableEntity , ITitle
    {
        public string Title { get; set; }
        public string? Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }

        public ICollection<Post> Posts { get; set; } = new List<Post>();
    }
}
