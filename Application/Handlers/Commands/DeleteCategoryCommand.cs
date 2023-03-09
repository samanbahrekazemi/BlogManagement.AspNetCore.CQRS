using Application.Common.Interfaces;
using Application.Common.Models;
using MediatR;

namespace Application.Handlers.Commands
{
    public class DeleteCategoryCommand : IRequest<Result>
    {
        public DeleteCategoryCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }


    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, Result>
    {
        private readonly ICategoryService _cateoryService;

        public DeleteCategoryCommandHandler(ICategoryService categoryService)
        {
            _cateoryService = categoryService;
        }

        public async Task<Result> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            return await _cateoryService.DeleteAsync(request.Id);
        }
    }
}
