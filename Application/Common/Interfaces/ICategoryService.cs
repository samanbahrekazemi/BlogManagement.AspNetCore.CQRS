using Application.Common.Models;
using Application.DTOs;

namespace Application.Common.Interfaces
{
    public interface ICategoryService
    {
        Task<Result<CategoryDto>> CreateAsync(CreateCategoryDto dto);
        Task<Result<CategoryDto>> UpdateAsync(int id, UpdateCategoryDto dto);
        Task<Result> DeleteAsync(int id);
        Task<CategoryDto?> FindAsync(int id);
        Task<Result<CategoryDto?>> GetByIdAsync(int id);
        Task<Result<IEnumerable<CategoryDto>>> GetAllAsync();
    }
}
