using Dentist.Application.Features.Mediator.Commands.CommentCommands;
using Dentist.Application.Features.Mediator.Queries.CommentQueries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dentist.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CommentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetComments()
        {
            return Ok(await _mediator.Send(new GetCommentQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCommentById(int id)
        {
            return Ok(await _mediator.Send(new GetCommentByIdQuery(id)));
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment(CreateCommentCommand command)
        {
            await _mediator.Send(command);
            return Ok("Comment created succesfully");
        }

        [HttpPost("Update")]
        public async Task<IActionResult> UpdateComment(UpdateCommentCommand command)
        {
            await _mediator.Send(command);
            return Ok("Comment updated succesfully");
        }

        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            await _mediator.Send(new RemoveCommentCommand(id));
            return Ok("Comment deleted succesfully");
        }

    }
}
