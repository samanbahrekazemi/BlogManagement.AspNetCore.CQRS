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
    public class PostService : IPostService
    {
        private readonly ILogger<PostService> _logger;
        private readonly IRepository<Post, int> _repository;
        private readonly IMapper _mapper;


        public PostService(ILogger<PostService> logger, IRepository<Post, int> repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }


        public async Task<Result<PostDto>> CreateAsync(CreatePostDto dto)
        {
            try
            {
                if (string.IsNullOrEmpty(dto.Title))
                    throw new ArgumentNullException(nameof(dto.Title));

                var post = _mapper.Map<Post>(dto);
                var entry = await _repository.AddAsync(post);
                return Result<PostDto>.Success(_mapper.Map<PostDto>(entry));
            }
            catch (Exception ex)
            {
                return Result<PostDto>.Failure(ex.InnerException?.Message ?? ex.Message);
            }
        }

        public async Task<Result<PostDto>> UpdateAsync(int id, UpdatePostDto dto)
        {
            try
            {
                var entity = await _repository.FindByAsync(id);
                if (entity == null) throw new NotFoundException(nameof(Post), id);
                var entry = await _repository.UpdateAsync(_mapper.Map(dto, entity));
                return Result<PostDto>.Success(_mapper.Map<PostDto>(entry));

            }
            catch (Exception ex)
            {
                return Result<PostDto>.Failure(ex.Message);
            }
        }

        public async Task<Result> DeleteAsync(int id)
        {
            try
            {
                var entity = await _repository.FindByAsync(id);
                if (entity == null) throw new NotFoundException(nameof(Post), id);
                await _repository.DeleteAsync(entity);
                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Failure(ex.InnerException?.Message ?? ex.Message);
            }
        }

        public async Task<PostDto?> FindAsync(int id)
        {
            return _mapper.Map<PostDto?>(await _repository.FindByAsync(id));
        }

        public async Task<Result<IEnumerable<PostDto>>> GetAllAsync()
        {
            var posts = await _repository.GetAllAsync();
            return Result<IEnumerable<PostDto>>.Success(_mapper.Map<IEnumerable<PostDto>>(posts));
        }

        public async Task<Result<PostDto?>> GetByIdAsync(int id)
        {
            try
            {
                var entity = await _repository.GetByIdAsync(id);
                if (entity == null) throw new NotFoundException(nameof(Post), id);
                return Result<PostDto?>.Success(_mapper.Map<PostDto>(entity));
            }
            catch (Exception ex)
            {
                return Result<PostDto?>.Failure(ex.Message);
            }
        }


    }
}
