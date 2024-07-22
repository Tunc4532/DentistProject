using Dentist.Application.Features.Mediator.Commands.AboutCommands;
using Dentist.Application.Features.Mediator.Commands.CoverLetterCommands;
using Dentist.Application.Features.Mediator.Queries.AboutQueries;
using Dentist.Application.Features.Mediator.Queries.CoverLetterQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dentist.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoverLettersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CoverLettersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetCoverLetters()
        {
            return Ok(await _mediator.Send(new GetCoverLetterQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GeCoverLetterById(int id)
        {
            return Ok(await _mediator.Send(new GetCoverLetterByIdQuery(id)));
        }

        [HttpPost]
        public async Task<IActionResult> CreateCoverLetter(CreateCoverLetterCommand command)
        {
            await _mediator.Send(command);
            return Ok("CoverLetter created succesfully");
        }

        [HttpPost("Update")]
        public async Task<IActionResult> UpdateCoverLetter(UpdateCoverLetterCommand command)
        {
            await _mediator.Send(command);
            return Ok("CoverLetter updated succesfully");
        }

        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> DeleteCoverLetter(int id)
        {
            await _mediator.Send(new RemoveCoverLetterCommand(id));
            return Ok("CoverLetter deleted succesfully");
        }

    }
}
