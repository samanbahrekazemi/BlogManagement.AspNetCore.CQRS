using Application.Common.Interfaces;
using Application.Common.Models;
using Application.DTOs;
using MediatR;

namespace Application.Handlers.Queries
{
    public class GetPostsQuery : IRequest<Result<IEnumerable<PostDto>>>
    {
    }

    public class GetPostsQueryHandler : IRequestHandler<GetPostsQuery, Result<IEnumerable<PostDto>>>
    {
        private readonly IPostService _postService;
        public GetPostsQueryHandler(IPostService postService)
        {
            _postService = postService;
        }
        public async Task<Result<IEnumerable<PostDto>>> Handle(GetPostsQuery request, CancellationToken cancellationToken)
        {
            return await _postService.GetAllAsync();
        }
    }
}
