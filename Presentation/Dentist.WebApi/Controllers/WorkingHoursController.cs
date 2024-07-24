using Dentist.Application.Features.Mediator.Commands.AboutCommands;
using Dentist.Application.Features.Mediator.Commands.WorkingHourCommands;
using Dentist.Application.Features.Mediator.Queries.AboutQueries;
using Dentist.Application.Features.Mediator.Queries.WorkingHourQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dentist.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkingHoursController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WorkingHoursController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetWorkingHours()
        {
            return Ok(await _mediator.Send(new GetWorkingHourQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetWorkingHourById(int id)
        {
            return Ok(await _mediator.Send(new GetWorkingHourByIdQuery(id)));
        }

        [HttpPost]
        public async Task<IActionResult> CreateWorkingHour(CreateWorkingHourCommand command)
        {
            await _mediator.Send(command);
            return Ok("WorkingHour created succesfully");
        }

        [HttpPost("Update")]
        public async Task<IActionResult> UpdateWorkingHour(UpdateWorkingHourCommand command)
        {
            await _mediator.Send(command);
            return Ok("WorkingHour updated succesfully");
        }

        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> DeleteWorkingHour(int id)
        {
            await _mediator.Send(new RemoveWorkingHourCommand(id));
            return Ok("WorkingHour deleted succesfully");
        }
    }
}
