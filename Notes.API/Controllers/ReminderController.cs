using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Notes.Application.Mediators.Reminder.Queries;
using Notes.Domain.DTO.Reminder;
using Notes.Domain.Result;
using Reminders.Application.Mediators.Reminder.Commands;
using Reminders.Application.Mediators.Reminder.Queries;

namespace Reminders.API.Controllers
{
    [ApiController]
    [ApiVersion(1)]
    [Route("api/v{v:apiVersion}/function/[controller]")]
    public class ReminderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReminderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("get-all")]
        public async Task<ActionResult<BaseResult<ReminderDTO>>> GetReminders()
        {
            var response = await _mediator.Send(new GetRemindersQuery());

            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpGet("get")]
        public async Task<ActionResult<BaseResult<ReminderDTO>>> GetReminderById([FromQuery] long id)
        {
            var response = await _mediator.Send(new GetReminderByIdQuery(id));

            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpPost("create")]
        public async Task<ActionResult<BaseResult<ReminderDTO>>> Create([FromBody] CreateReminderCommand cmd)
        {
            var response = await _mediator.Send(cmd);

            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpPut("update")]
        public async Task<ActionResult<BaseResult<ReminderDTO>>> Update([FromBody] UpdateReminderCommand cmd)
        {
            var response = await _mediator.Send(cmd);

            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpDelete("delete")]
        public async Task<ActionResult<BaseResult<ReminderDTO>>> Delete([FromQuery] long id)
        {
            var response = await _mediator.Send(new DeleteReminderCommand(id));

            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpPost("set-tag")]
        public async Task<ActionResult<BaseResult<ReminderDTO>>> SetTag([FromBody] SetReminderTagCommand cmd)
        {
            var response = await _mediator.Send(cmd);

            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }
    }
}