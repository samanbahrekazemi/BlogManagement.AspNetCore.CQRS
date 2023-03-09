using Application.Common.Interfaces;
using Application.Common.Models;
using Application.DTOs;
using MediatR;

namespace Application.Handlers.Commands
{
    public class UpdatePostCommand : IRequest<Result<PostDto>>
    {
        public int Id { get; set; }
        public UpdatePostDto Post { get; set; }

        public UpdatePostCommand(int id, UpdatePostDto post)
        {
            Id = id;
            Post = post;
        }
    }


    public class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommand, Result<PostDto>>
    {
        private readonly IPostService _postService;

        public UpdatePostCommandHandler(IPostService postService)
        {
            _postService = postService;
        }

        public async Task<Result<PostDto>> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
        {
            return await _postService.UpdateAsync(request.Id, request.Post);
        }
    }
}
