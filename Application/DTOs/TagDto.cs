using Application.Common.Mapping;
using Core.Models;

namespace Application.DTOs
{
    public class TagDto : IMapFrom<Tag>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
