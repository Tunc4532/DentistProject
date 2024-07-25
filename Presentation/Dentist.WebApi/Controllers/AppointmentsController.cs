using Dentist.Application.Features.Mediator.Commands.AboutCommands;
using Dentist.Application.Features.Mediator.Commands.AppointmentCommands;
using Dentist.Application.Features.Mediator.Queries.AboutQueries;
using Dentist.Application.Features.Mediator.Queries.AppointmentQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dentist.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AppointmentsController : ControllerBase
	{
		private readonly IMediator _mediator;

		public AppointmentsController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<IActionResult> GetAppointments()
		{
			return Ok(await _mediator.Send(new GetAppointmentQuery()));
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetAppointmentById(int id)
		{
			return Ok(await _mediator.Send(new GetAppointmentByIdQuery(id)));
		}

		[HttpPost]
		public async Task<IActionResult> CreateAppointment(CreateAppointmentCommand command)
		{
			await _mediator.Send(command);
			return Ok("Appointment created succesfully");
		}

		[HttpPost("Update")]
		public async Task<IActionResult> UpdateAppointment(UpdateAppointmentCommand command)
		{
			await _mediator.Send(command);
			return Ok("Appointment updated succesfully");
		}

		[HttpGet("Delete/{id}")]
		public async Task<IActionResult> DeleteAppointment(int id)
		{
			await _mediator.Send(new RemoveAppointmentCommand(id));
			return Ok("Appointment deletede succesfully");
		}


	}
}
