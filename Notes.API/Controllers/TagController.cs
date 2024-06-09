using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Notes.Application.Mediators.Tag.Commands;
using Notes.Application.Mediators.Tag.Queries;
using Notes.Domain.DTO.Tag;
using Notes.Domain.Result;
using Reminders.Application.Mediators.Reminder.Queries;

namespace Tags.API.Controllers
{
    [ApiController]
    [ApiVersion(1)]
    [Route("api/v{v:apiVersion}/function/[controller]")]
    public class TagController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TagController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("get-all")]
        public async Task<ActionResult<BaseResult<TagDTO>>> GetTags()
        {
            var response = await _mediator.Send(new GetTagsQuery());

            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpGet("get")]
        public async Task<ActionResult<BaseResult<TagDTO>>> GetTagById([FromQuery] long id)
        {
            var response = await _mediator.Send(new GetReminderByIdQuery(id));

            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpPost("create")]
        public async Task<ActionResult<BaseResult<TagDTO>>> Create([FromBody] CreateTagCommand cmd)
        {
            var response = await _mediator.Send(cmd);

            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpPut("update")]
        public async Task<ActionResult<BaseResult<TagDTO>>> Update([FromBody] UpdateTagCommand cmd)
        {
            var response = await _mediator.Send(cmd);

            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpDelete("delete")]
        public async Task<ActionResult<BaseResult<TagDTO>>> Delete([FromQuery] long id)
        {
            var response = await _mediator.Send(new DeleteTagCommand(id));

            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }
    }
}