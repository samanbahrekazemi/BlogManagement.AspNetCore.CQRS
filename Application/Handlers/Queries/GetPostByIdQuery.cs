using Application.Common.Interfaces;
using Application.Common.Models;
using Application.DTOs;
using MediatR;

namespace Application.Handlers.Queries
{
    public class GetPostByIdQuery : IRequest<Result<PostDto?>>
    {
        public GetPostByIdQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }



    public class GetPostByIdQueryHandler : IRequestHandler<GetPostByIdQuery, Result<PostDto?>>
    {
        private readonly IPostService _postService;

        public GetPostByIdQueryHandler(IPostService postService)
        {
            _postService = postService;
        }

        public async Task<Result<PostDto?>> Handle(GetPostByIdQuery request, CancellationToken cancellationToken)
        {
            return await _postService.GetByIdAsync(request.Id);
        }
    }
}
