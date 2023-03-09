using Application.Common.Models;
using Application.DTOs;
using Application.Handlers.Commands;
using Application.Handlers.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TagsController(IMediator mediator)
        {
            _mediator = mediator;
        }



        [HttpGet("")]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new GetTagsQuery()));
        }


        [HttpGet("GetAllPaginated")]
        public async Task<ActionResult<Result<PaginatedList<TagDto>>>> GetAllPaginated([FromQuery] GetTagsPaginatedQuery query)
        {
            return Ok(await _mediator.Send(query));
        }



        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            try
            {
                var result = await _mediator.Send(new GetTagsByIdQuery(id));
                if (result == null) return NotFound();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Problem(ex.InnerException?.Message ?? ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateTagDto dto)
        {
            if (dto == null) return BadRequest();
            try
            {
                var result = await _mediator.Send(new CreateTagCommand(dto));
                if (result == null) return NotFound();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Problem(ex.InnerException?.Message ?? ex.Message);
            }
        }



        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateTagDto dto)
        {
            try
            {
                if (id != dto.Id) return BadRequest();
                var result = await _mediator.Send(new UpdateTagCommand(id, dto));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Problem(ex.InnerException?.Message ?? ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _mediator.Send(new DeleteTagCommand(id));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Problem(ex.InnerException?.Message ?? ex.Message);
            }
        }
    }
}
