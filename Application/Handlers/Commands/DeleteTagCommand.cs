using Application.Common.Interfaces;
using Application.Common.Models;
using MediatR;

namespace Application.Handlers.Commands
{
    public class DeleteTagCommand : IRequest<Result>
    {
        public DeleteTagCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }


    public class DeleteTagCommandHandler : IRequestHandler<DeleteTagCommand, Result>
    {
        private readonly ITagService _tagService;

        public DeleteTagCommandHandler(ITagService tagService)
        {
            _tagService = tagService;
        }

        public async Task<Result> Handle(DeleteTagCommand request, CancellationToken cancellationToken)
        {
            return await _tagService.DeleteAsync(request.Id);
        }
    }
}
