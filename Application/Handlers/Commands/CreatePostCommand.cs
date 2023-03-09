using Application.Common.Interfaces;
using Application.Common.Models;
using Application.DTOs;
using MediatR;

namespace Application.Handlers.Commands
{
    public class CreatePostCommand : IRequest<Result<PostDto>>
    {
        public CreatePostCommand(CreatePostDto postDto)
        {
            Dto = postDto;
        }
        public CreatePostDto Dto { get; set; }
    }


    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, Result<PostDto>>
    {
        private readonly IPostService _postService;

        public CreatePostCommandHandler(IPostService postService)
        {
            _postService = postService;
        }

        public async Task<Result<PostDto>> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            return await _postService.CreateAsync(request.Dto);
        }
    }
}
