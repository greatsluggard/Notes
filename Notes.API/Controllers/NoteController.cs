using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Notes.Application.Mediators.Note.Commands;
using Notes.Application.Mediators.Note.Queries;
using Notes.Domain.DTO.Note;
using Notes.Domain.Result;

namespace Notes.API.Controllers
{
    [ApiController]
    [ApiVersion(1)]
    [Route("api/v{v:apiVersion}/function/[controller]")]
    public class NoteController : ControllerBase
    {
        private readonly IMediator _mediator;

        public NoteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("get-all")]
        public async Task<ActionResult<BaseResult<NoteDTO>>> GetNotes()
        {
            var response = await _mediator.Send(new GetNotesQuery());

            if(response.IsSuccess)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpGet("get")]
        public async Task<ActionResult<BaseResult<NoteDTO>>> GetNoteById([FromQuery] long id)
        {
            var response = await _mediator.Send(new GetNoteByIdQuery(id));

            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpPost("create")]
        public async Task<ActionResult<BaseResult<NoteDTO>>> Create([FromBody] CreateNoteCommand cmd)
        {
            var response = await _mediator.Send(cmd);

            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpPut("update")]
        public async Task<ActionResult<BaseResult<NoteDTO>>> Update([FromBody] UpdateNoteCommand cmd)
        {
            var response = await _mediator.Send(cmd);

            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpDelete("delete")]
        public async Task<ActionResult<BaseResult<NoteDTO>>> Delete([FromQuery] long id)
        {
            var response = await _mediator.Send(new DeleteNoteCommand(id));

            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpPost("set-tag")]
        public async Task<ActionResult<BaseResult<NoteDTO>>> SetTag([FromBody] SetNodeTagCommand cmd)
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