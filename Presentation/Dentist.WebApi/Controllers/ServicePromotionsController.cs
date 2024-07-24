using Dentist.Application.Features.Mediator.Commands.ServicePromotionCommands;
using Dentist.Application.Features.Mediator.Queries.ServicePromotionQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dentist.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicePromotionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ServicePromotionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetServicePromotion()
        {
            return Ok(await _mediator.Send(new GetServicePromotionQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetServicePromotionById(int id)
        {
            return Ok(await _mediator.Send(new GetServicePromotionByIdQuery(id)));
        }

        [HttpPost]
        public async Task<IActionResult> CreateServicePromotion(CreateServicePromotionCommand command)
        {
            await _mediator.Send(command);
            return Ok("ServicePromotion created succesfully");
        }

        [HttpPost("Update")]
        public async Task<IActionResult> UpdateServicePromotion(UpdateServicePromotionCommand command)
        {
            await _mediator.Send(command);
            return Ok("ServicePromotion updated succesfully");
        }

        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> DeleteServicePromotion(int id)
        {
            await _mediator.Send(new RemoveServicePromotionCommand(id));
            return Ok("ServicePromotion deleted succesfully");
        }
    }
}
