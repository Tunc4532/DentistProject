using Dentist.Application.Features.Mediator.Commands.AboutCommands;
using Dentist.Application.Features.Mediator.Commands.EducationCommands;
using Dentist.Application.Features.Mediator.Queries.AboutQueries;
using Dentist.Application.Features.Mediator.Queries.EducationQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dentist.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EducationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetEducations()
        {
            return Ok(await _mediator.Send(new GetEducationQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEducationById(int id)
        {
            return Ok(await _mediator.Send(new GetEducationByIdQuery(id)));
        }

        [HttpPost]
        public async Task<IActionResult> CreateEducation(CreateEducationCommand command)
        {
            await _mediator.Send(command);
            return Ok("Education created succesfully");
        }

        [HttpPost("Update")]
        public async Task<IActionResult> UpdateEducation(UpdateEducationCommand command)
        {
            await _mediator.Send(command);
            return Ok("Education updated succesfully");
        }

        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> DeleteEducation(int id)
        {
            await _mediator.Send(new RemoveEducationCommand(id));
            return Ok("Education deleted succesfully");
        }
    }
}
