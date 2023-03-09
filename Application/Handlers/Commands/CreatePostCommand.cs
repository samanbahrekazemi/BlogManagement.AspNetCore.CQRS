using Application.Common.Interfaces;
using Application.Common.Models;
using Application.DTOs;
using Application.Handlers.Validators;
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
        private readonly CreatePostCommandValidator _validator;
        public CreatePostCommandHandler(IPostService postService, CreatePostCommandValidator validator)
        {
            _postService = postService;
            _validator = validator;
        }

        public async Task<Result<PostDto>> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
                return Result<PostDto>.Failure(validationResult.Errors.FirstOrDefault()?.ErrorMessage ?? "");

            return await _postService.CreateAsync(request.Dto);
        }
    }
}
