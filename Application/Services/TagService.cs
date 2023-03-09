using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Common.Models;
using Application.DTOs;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Core.Models;
using Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;

namespace Application.Services
{
    public class TagService : ITagService
    {
        private readonly IRepository<Tag, int> _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<TagService> _logger;
        public TagService(IMapper mapper, ILogger<TagService> logger, IRepository<Tag, int> repository)
        {
            _mapper = mapper;
            _logger = logger;
            _repository = repository;
        }

        public async Task<Result<TagDto>> CreateAsync(CreateTagDto dto)
        {
            try
            {
                var post = _mapper.Map<Tag>(dto);
                var entry = await _repository.AddAsync(post);
                return Result<TagDto>.Success(_mapper.Map<TagDto>(entry));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.InnerException?.Message ?? ex.Message);
                return Result<TagDto>.Failure(ex.InnerException?.Message ?? ex.Message);
            }
        }

        public async Task<Result> DeleteAsync(int id)
        {
            try
            {
                var entity = await _repository.FindByAsync(id);
                if (entity == null) throw new NotFoundException(nameof(Tag), id);
                await _repository.DeleteAsync(entity);
                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Failure(ex.InnerException?.Message ?? ex.Message);
            }
        }

        public async Task<TagDto?> FindAsync(int id)
        {
            return _mapper.Map<TagDto?>(await _repository.FindByAsync(id));

        }

        public async Task<Result<IEnumerable<TagDto>>> GetAllAsync()
        {
            var posts = await _repository.GetAllAsync();
            return Result<IEnumerable<TagDto>>.Success(_mapper.Map<IEnumerable<TagDto>>(posts));
        }

        public async Task<Result<PaginatedList<TagDto>>> GetAllPaginatedAsync(string? q = "", int page = 1, int size = 10)
        {
            try
            {
                var query = _repository.AsQuerable();

                if (!string.IsNullOrEmpty(q))
                    query = query.Where(x => x.Name.Contains(q));

               var data = await query.OrderByDescending(x => x.CreatedAt).ThenBy(a => a.Name)
               .ProjectTo<TagDto>(_mapper.ConfigurationProvider)
               .PaginatedListAsync(page, size);

                return Result<PaginatedList<TagDto>>.Success(data);
            }
            catch (Exception ex)
            {
                return Result<PaginatedList<TagDto>>.Failure(ex.InnerException?.Message ?? ex.Message);
            }
        }

        public async Task<Result<TagDto?>> GetByIdAsync(int id)
        {
            try
            {
                var entity = await _repository.GetByIdAsync(id);
                if (entity == null) throw new NotFoundException(nameof(Tag), id);
                return Result<TagDto?>.Success(_mapper.Map<TagDto>(entity));
            }
            catch (Exception ex)
            {
                return Result<TagDto?>.Failure(ex.Message);
            }
        }

        public async Task<Result<TagDto>> UpdateAsync(int id, UpdateTagDto dto)
        {
            try
            {
                var entity = await _repository.FindByAsync(id);
                if (entity == null) throw new NotFoundException(nameof(Tag), id);
                _mapper.Map(dto, entity);
                var entry = await _repository.UpdateAsync(entity);
                return Result<TagDto>.Success(_mapper.Map<TagDto>(entry));
            }
            catch (Exception ex)
            {
                return Result<TagDto>.Failure(ex.Message);
            }
        }
    }
}
