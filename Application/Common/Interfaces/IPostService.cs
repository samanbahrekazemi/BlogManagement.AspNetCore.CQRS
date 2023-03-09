using Application.Common.Models;
using Application.DTOs;

namespace Application.Common.Interfaces
{
    public interface IPostService
    {
        Task<Result<PostDto>> CreateAsync(CreatePostDto dto);
        Task<Result<PostDto>> UpdateAsync(int id, UpdatePostDto dto);
        Task<Result> DeleteAsync(int id);
        Task<PostDto?> FindAsync(int id);
        Task<Result<PostDto?>> GetByIdAsync(int id);
        Task<Result<IEnumerable<PostDto>>> GetAllAsync();
    }
}
