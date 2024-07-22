using Dentist.Application.Features.Mediator.Commands.AboutCommands;
using Dentist.Application.Features.Mediator.Commands.CommentCommands;
using Dentist.Application.Features.Mediator.Queries.AboutQueries;
using Dentist.Application.Features.Mediator.Queries.CommentQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dentist.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AboutsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAbouts()
        {
            return Ok(await _mediator.Send(new GetAboutQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAboutById(int id)
        {
            return Ok(await _mediator.Send(new GetAboutByIdQuery(id)));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutCommand command)
        {
            await _mediator.Send(command);
            return Ok("About created succesfully");
        }

        [HttpPost("Update")]
        public async Task<IActionResult> UpdateAbout(UpdateAboutCommand command)
        {
            await _mediator.Send(command);
            return Ok("About updated succesfully");
        }

        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> DeleteAbout(int id)
        {
            await _mediator.Send(new RemoveAboutCommand(id));
            return Ok("About deleted succesfully");
        }
    }
}
