using Dentist.Application.Features.Mediator.Commands.AboutCommands;
using Dentist.Application.Features.Mediator.Commands.ServiceCardCommands;
using Dentist.Application.Features.Mediator.Queries.AboutQueries;
using Dentist.Application.Features.Mediator.Queries.ServiceCardQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dentist.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceCardsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ServiceCardsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetServiceCards()
        {
            return Ok(await _mediator.Send(new GetServiceCardQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetServiceCardById(int id)
        {
            return Ok(await _mediator.Send(new GetAboutByIdQuery(id)));
        }

        [HttpPost]
        public async Task<IActionResult> CreateServiceCard(CreateServiceCardCommand command)
        {
            await _mediator.Send(command);
            return Ok("ServiceCard created succesfully");
        }

        [HttpPost("Update")]
        public async Task<IActionResult> UpdateServiceCard(UpdateServiceCardCommand command)
        {
            await _mediator.Send(command);
            return Ok("ServiceCard updated succesfully");
        }

        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> DeleteServiceCard(int id)
        {
            await _mediator.Send(new RemoveServiceCardCommand(id));
            return Ok("ServiceCard deleted succesfully");
        }
    }
}
