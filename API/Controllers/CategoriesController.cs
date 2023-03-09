using Application.DTOs;
using Application.Handlers.Commands;
using Application.Handlers.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("")]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new GetCategoriesQuery()));
        }


        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var query = new GetCategoryByIdQuery(id);
            var result = await _mediator.Send(query);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateCategoryDto categoryDto)
        {
            if (categoryDto == null) return BadRequest();

            var query = new CreateCategoryCommand(categoryDto);
            var result = await _mediator.Send(query);
            if (result == null) return NotFound();
            return Ok(result);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateCategoryDto postDto)
        {
            if (id != postDto.Id) return BadRequest();
            var result = await _mediator.Send(new UpdateCategoryCommand(id, postDto));
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteCategoryCommand(id);
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
