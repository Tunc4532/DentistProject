using Dentist.Application.Features.Mediator.Commands.AboutCommands;
using Dentist.Application.Features.Mediator.Commands.PatientCommands;
using Dentist.Application.Features.Mediator.Queries.AboutQueries;
using Dentist.Application.Features.Mediator.Queries.PatientQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dentist.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PatientsController : ControllerBase
	{
		private readonly IMediator _mediator;

		public PatientsController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<IActionResult> GetPatients()
		{
			return Ok(await _mediator.Send(new GetPatientQuery()));
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetPatientById(int id)
		{
			return Ok(await _mediator.Send(new GetPatientByIdQuery(id)));
		}

		[HttpPost]
		public async Task<IActionResult> CreatePatient(CreatePatientCommand command)
		{
			await _mediator.Send(command);
			return Ok("Patient created succesfully");
		}

		[HttpPost("Update")]
		public async Task<IActionResult> UpdatePatient(UpdatePatientCommand command)
		{
			await _mediator.Send(command);
			return Ok("Patient updated succesfully");
		}

		[HttpGet("Delete/{id}")]
		public async Task<IActionResult> DeletePatient(int id)
		{
			await _mediator.Send(new RemovePatientCommand(id));
			return Ok("Patient deleted succesfully");
		}
	}
}
