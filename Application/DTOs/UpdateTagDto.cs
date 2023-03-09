using Application.Common.Mapping;

namespace Application.DTOs
{
    public class UpdateTagDto : IMapFrom<TagDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
