using Application.DTOs;
using Application.Handlers.Commands;
using Application.Handlers.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PostsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("")]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new GetPostsQuery()));
        }


        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var query = new GetPostByIdQuery(id);
            var result = await _mediator.Send(query);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreatePostDto postDto)
        {
            if (postDto == null) return BadRequest();
            var result = await _mediator.Send(new CreatePostCommand(postDto));
            if (result == null) return NotFound();
            return Ok(result);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdatePostDto postDto)
        {
            if (id != postDto.Id) return BadRequest();
            var result = await _mediator.Send(new UpdatePostCommand(id, postDto));
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _mediator.Send(new DeletePostCommand(id)));
        }
    }
}
