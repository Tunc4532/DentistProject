using Dentist.Application.Features.Mediator.Commands.CommentCommands;
using Dentist.Application.Features.Mediator.Commands.SliderCommands;
using Dentist.Application.Features.Mediator.Queries.CommentQueries;
using Dentist.Application.Features.Mediator.Queries.SliderQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dentist.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SlidersesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SlidersesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetSliders()
        {
            return Ok(await _mediator.Send(new GetSliderQuery()));
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetSliderById(int id)
        {
            return Ok(await _mediator.Send(new GetSliderByIdQuery(id)));
        }

        [HttpPost]
        public async Task<IActionResult> CreateSlider(CreateSliderCommand command)
        {
            await _mediator.Send(command);
            return Ok("Slider created succesfully");
        }

        [HttpPost("Update")]
        public async Task<IActionResult> UpdateSlider(UpdateSliderCommand command)
        {
            await _mediator.Send(command);
            return Ok("Slider updated succesfully");
        }

        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> DeleteSlider(int id)
        {
            await _mediator.Send(new RemoveSliderCommand(id));
            return Ok("Slider deleted succesfully");
        }
    }
}
