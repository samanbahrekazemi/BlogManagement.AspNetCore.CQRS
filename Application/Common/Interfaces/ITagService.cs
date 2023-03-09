using Application.Common.Models;
using Application.DTOs;

namespace Application.Common.Interfaces
{
    public interface ITagService
    {
        Task<Result<TagDto>> CreateAsync(CreateTagDto dto);
        Task<Result<TagDto>> UpdateAsync(int id, UpdateTagDto dto);
        Task<Result> DeleteAsync(int id);
        Task<TagDto?> FindAsync(int id);
        Task<Result<TagDto?>> GetByIdAsync(int id);
        Task<Result<IEnumerable<TagDto>>> GetAllAsync();
        Task<Result<PaginatedList<TagDto>>> GetAllPaginatedAsync(string? q = "", int page = 1, int size = 10);
    }
}
