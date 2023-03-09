using Core.Common;
using Core.Interfaces;

namespace Core.Models
{
    public class Tag : EntityBase<int>, IAuditableEntity
    {
        public string Title { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }


        public ICollection<PostTag> PostTags { get; set; } = new List<PostTag>();

    }
}
