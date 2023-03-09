using Application.Common.Mapping;
using Core.Interfaces;
using Core.Models;

namespace Application.DTOs
{
    public class TagDto : IMapFrom<Tag> , ITitle
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
