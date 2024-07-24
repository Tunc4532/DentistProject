using Dentist.Application.Features.Mediator.Commands.SupportCommands;
using Dentist.Application.Features.Mediator.Queries.SupportQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dentist.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupportsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SupportsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetSupports()
        {
            return Ok(await _mediator.Send(new GetSupportQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSupportById(int id)
        {
            return Ok(await _mediator.Send(new GetSupportByIdQuery(id)));
        }

        [HttpPost]
        public async Task<IActionResult> CreateSupport(CreateSupportCommand command)
        {
            await _mediator.Send(command);
            return Ok("Support created succesfully");
        }

        [HttpPost("Update")]
        public async Task<IActionResult> UpdateSupport(UpdateSupportCommand command)
        {
            await _mediator.Send(command);
            return Ok("Support updated succesfully");
        }

        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> DeleteSupport(int id)
        {
            await _mediator.Send(new RemoveSupportCommand(id));
            return Ok("Support deleted succesfully");
        }
    }
}
