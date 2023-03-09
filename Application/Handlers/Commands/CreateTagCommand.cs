using Application.Common.Interfaces;
using Application.Common.Models;
using Application.DTOs;
using MediatR;

namespace Application.Handlers.Commands
{
    public class CreateTagCommand : IRequest<Result<TagDto>>
    {
        public CreateTagCommand(CreateTagDto categoryDto)
        {
            TagDto = categoryDto;
        }
        public CreateTagDto TagDto { get; set; }
    }



    public class CreateTagCommandHandler : IRequestHandler<CreateTagCommand, Result<TagDto>>
    {
        private readonly ITagService _service;

        public CreateTagCommandHandler(ITagService service)
        {
            _service = service;
        }

        public async Task<Result<TagDto>> Handle(CreateTagCommand request, CancellationToken cancellationToken)
        {
            return await _service.CreateAsync(request.TagDto);
        }
    }
}