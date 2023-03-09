using Application.Common.Interfaces;
using Application.Common.Models;
using Application.DTOs;
using MediatR;

namespace Application.Handlers.Queries
{
    public class GetTagsQuery : IRequest<Result<IEnumerable<TagDto>>>
    {
    }

    public class GetTagsQueryHandler : IRequestHandler<GetTagsQuery, Result<IEnumerable<TagDto>>>
    {
        private readonly ITagService _tagService;
        public GetTagsQueryHandler(ITagService tagService)
        {
            _tagService = tagService;
        }
        public async Task<Result<IEnumerable<TagDto>>> Handle(GetTagsQuery request, CancellationToken cancellationToken)
        {
            return await _tagService.GetAllAsync();
        }
    }
}
