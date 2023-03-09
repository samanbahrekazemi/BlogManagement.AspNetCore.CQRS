using Application.Common.Interfaces;
using Application.Common.Models;
using Application.DTOs;
using MediatR;

namespace Application.Handlers.Commands
{
    public class UpdateTagCommand : IRequest<Result<TagDto>>
    {
        public int Id { get; set; }
        public UpdateTagDto Category { get; set; }

        public UpdateTagCommand(int id, UpdateTagDto category)
        {
            Id = id;
            Category = category;
        }
    }


    public class UpdateTagCommandHandler : IRequestHandler<UpdateTagCommand, Result<TagDto>>
    {
        private readonly ITagService _tagService;

        public UpdateTagCommandHandler(ITagService tagService)
        {
            _tagService = tagService;
        }

        public async Task<Result<TagDto>> Handle(UpdateTagCommand request, CancellationToken cancellationToken)
        {
            return await _tagService.UpdateAsync(request.Id, request.Category);
        }
    }
}
