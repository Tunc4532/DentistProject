using Dentist.Application.Features.Mediator.Commands.AboutCommands;
using Dentist.Application.Features.Mediator.Commands.SkillCommands;
using Dentist.Application.Features.Mediator.Queries.AboutQueries;
using Dentist.Application.Features.Mediator.Queries.SkillQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dentist.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SkillsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetSkills()
        {
            return Ok(await _mediator.Send(new GetSkillQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSkillById(int id)
        {
            return Ok(await _mediator.Send(new GetSkillByIdQuery(id)));
        }

        [HttpPost]
        public async Task<IActionResult> CreateSkill(CreateSkillCommand command)
        {
            await _mediator.Send(command);
            return Ok("Skill created succesfully");
        }

        [HttpPost("Update")]
        public async Task<IActionResult> UpdateSkill(UpdateSkillCommand command)
        {
            await _mediator.Send(command);
            return Ok("Skill updated succesfully");
        }

        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> DeleteSkill(int id)
        {
            await _mediator.Send(new RemoveSkillCommand(id));
            return Ok("Skill deleted succesfully");
        }
    }
}
