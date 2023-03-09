using Application.Common.Mapping;
using Core.Models;

namespace Application.DTOs;

public class CategoryDto : IMapFrom<Category>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Content { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? ModifiedAt { get; set; }
    public int PostsCount => Posts.Count;
    public List<Post> Posts { get; set; } 
}
