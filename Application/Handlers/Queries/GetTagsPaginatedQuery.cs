using Application.Common.Interfaces;
using Application.Common.Models;
using Application.DTOs;
using MediatR;

namespace Application.Handlers.Queries
{
    public class GetTagsPaginatedQuery : IRequest<Result<PaginatedList<TagDto>>>
    {
        public string? Q { get; init; } = string.Empty;
        public int PageNumber { get; init; } = 1;
        public int PageSize { get; init; } = 10;
    }


    public class GetTagsPaginatedQueryHandler : IRequestHandler<GetTagsPaginatedQuery, Result<PaginatedList<TagDto>>>
    {
        private readonly ITagService _tagService;
        public GetTagsPaginatedQueryHandler(ITagService tagService)
        {
            _tagService = tagService;
        }

        public async Task<Result<PaginatedList<TagDto>>> Handle(GetTagsPaginatedQuery request, CancellationToken cancellationToken)
        {
            return await _tagService.GetAllPaginatedAsync(request.Q, request.PageNumber, request.PageSize);
        }
    }

}
