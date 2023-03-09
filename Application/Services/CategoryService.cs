using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Common.Models;
using Application.DTOs;
using AutoMapper;
using Core.Models;
using Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;

namespace Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category, int> _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<CategoryService> _logger;

        public CategoryService(IMapper mapper, ILogger<CategoryService> logger, IRepository<Category, int> repository)
        {
            _mapper = mapper;
            _logger = logger;
            _repository = repository;
        }


        public async Task<Result<CategoryDto>> CreateAsync(CreateCategoryDto dto)
        {
            try
            {
                var entity = _mapper.Map<Category>(dto);
                var entry = await _repository.AddAsync(entity);
                return Result<CategoryDto>.Success(_mapper.Map<CategoryDto>(entry));
            }
            catch (Exception ex)
            {
                return Result<CategoryDto>.Failure(ex.InnerException?.Message ?? ex.Message);
            }
        }

        public async Task<Result> DeleteAsync(int id)
        {
            var model = await _repository.FindByAsync(id);
            if (model == null) throw new NotFoundException(nameof(Category), id);

            try
            {
                await _repository.DeleteAsync(model);
                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Failure(ex.InnerException?.Message ?? ex.Message);
            }
        }

        public async Task<CategoryDto?> FindAsync(int id)
        {
            var entity = await _repository.FindByAsync(id);
            return entity == null ? null : _mapper.Map<CategoryDto?>(entity);
        }

        public async Task<Result<IEnumerable<CategoryDto>>> GetAllAsync()
        {
            try
            {
                var list = await _repository.GetAllAsync();
                return Result<IEnumerable<CategoryDto>>.Success(_mapper.Map<IEnumerable<CategoryDto>>(list));
            }
            catch (Exception ex)
            {
                return Result<IEnumerable<CategoryDto>>.Failure(ex.InnerException?.Message ?? ex.Message);
            }
        }

        public async Task<Result<CategoryDto?>> GetByIdAsync(int id)
        {
            try
            {
                var model = await _repository.GetByIdAsync(id);
                if (model == null) throw new NotFoundException(nameof(Category), id);
                return Result<CategoryDto?>.Success(_mapper.Map<CategoryDto>(model));
            }
            catch (Exception ex)
            {
                return Result<CategoryDto?>.Failure(ex.Message);
            }
        }

        public async Task<Result<CategoryDto>> UpdateAsync(int id, UpdateCategoryDto categoryDto)
        {
            try
            {
                var model = await _repository.GetByIdAsync(id);
                if (model == null) throw new NotFoundException(nameof(Category), id);
                var entry = await _repository.UpdateAsync(_mapper.Map(categoryDto, model));
                return Result<CategoryDto>.Success(_mapper.Map<CategoryDto>(entry));
            }
            catch (Exception ex)
            {
                return Result<CategoryDto>.Failure(ex.Message);
            }

        }
    }
}
