using Application.Common.Interfaces;
using Application.Common.Models;
using MediatR;

namespace Application.Handlers.Commands
{
    public class DeletePostCommand : IRequest<Result>
    {
        public DeletePostCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }


    public class DeletePostCommandHandler : IRequestHandler<DeletePostCommand, Result>
    {
        private readonly IPostService _postService;

        public DeletePostCommandHandler(IPostService postService)
        {
            _postService = postService;
        }

        public async Task<Result> Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {
            return await _postService.DeleteAsync(request.Id);
        }
    }
}
