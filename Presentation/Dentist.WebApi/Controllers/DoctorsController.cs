using Dentist.Application.Features.Mediator.Commands.AboutCommands;
using Dentist.Application.Features.Mediator.Commands.DoctorCommands;
using Dentist.Application.Features.Mediator.Queries.AboutQueries;
using Dentist.Application.Features.Mediator.Queries.DoctorQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dentist.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DoctorsController : ControllerBase
	{
		private readonly IMediator _mediator;

		public DoctorsController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<IActionResult> GetDoctors()
		{
			return Ok(await _mediator.Send(new GetDoctorQuery()));
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetDoctorById(int id)
		{
			return Ok(await _mediator.Send(new GetDoctorByIdQuery(id)));
		}

		[HttpPost]
		public async Task<IActionResult> CreateDoctor(CreateDoctorCommand command)
		{
			await _mediator.Send(command);
			return Ok("Doctor created succesfully");
		}

		[HttpPost("Update")]
		public async Task<IActionResult> UpdateDoctor(UpdateDoctorCommand command)
		{
			await _mediator.Send(command);
			return Ok("Doctor updated succesfully");
		}

		[HttpGet("Delete/{id}")]
		public async Task<IActionResult> DeleteDoctor(int id)
		{
			await _mediator.Send(new RemoveDoctorCommand(id));
			return Ok("Doctor deleted succesfully");
		}

	}
}
