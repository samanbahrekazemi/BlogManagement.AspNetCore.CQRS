using Application.Common.Interfaces;
using Application.Common.Models;
using Application.DTOs;
using MediatR;

namespace Application.Handlers.Queries
{
    public class GetTagsByIdQuery : IRequest<Result<TagDto?>>
    {
        public GetTagsByIdQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }



    public class GetTagsByIdQueryHandler : IRequestHandler<GetTagsByIdQuery, Result<TagDto?>>
    {
        private readonly ITagService _tagService;

        public GetTagsByIdQueryHandler(ITagService tagService)
        {
            _tagService = tagService;
        }

        public async Task<Result<TagDto?>> Handle(GetTagsByIdQuery request, CancellationToken cancellationToken)
        {
            return await _tagService.GetByIdAsync(request.Id);
        }
    }
}
