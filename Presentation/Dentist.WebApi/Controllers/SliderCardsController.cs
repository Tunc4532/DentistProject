using Dentist.Application.Features.Mediator.Commands.ServicePromotionCommands;
using Dentist.Application.Features.Mediator.Commands.SliderCardCommands;
using Dentist.Application.Features.Mediator.Queries.ServicePromotionQueries;
using Dentist.Application.Features.Mediator.Queries.SliderCardQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dentist.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SliderCardsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SliderCardsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetSliderCards()
        {
            return Ok(await _mediator.Send(new GetSliderCardQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSliderCardById(int id)
        {
            return Ok(await _mediator.Send(new GetSliderCardByIdQuery(id)));
        }

        [HttpPost]
        public async Task<IActionResult> CreateSliderCard(CreateSliderCardCommand command)
        {
            await _mediator.Send(command);
            return Ok("SliderCard created succesfully");
        }

        [HttpPost("Update")]
        public async Task<IActionResult> UpdateSliderCard(UpdateSliderCardCommand command)
        {
            await _mediator.Send(command);
            return Ok("SliderCard updated succesfully");
        }

        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> DeleteSliderCard(int id)
        {
            await _mediator.Send(new RemoveSliderCardCommand(id));
            return Ok("SliderCard deleted succesfully");
        }
    }
}
