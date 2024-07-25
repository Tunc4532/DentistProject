using Dentist.Application.Features.Mediator.Commands.AppointmentCommands;
using Dentist.Application.Interfaces;
using Dentist.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentist.Application.Features.Mediator.Handlers.AppointmentHandlers
{
	public class CreateAppointmentCommandHandler : IRequestHandler<CreateAppointmentCommand>
	{
		private readonly IRepository<Appointment> _repository;

		public CreateAppointmentCommandHandler(IRepository<Appointment> repository)
		{
			_repository = repository;
		}

		public async Task Handle(CreateAppointmentCommand request, CancellationToken cancellationToken)
		{
			await _repository.CreateAsync(new Appointment
			{
				IsAvailable = true,
				DoctorId = request.DoctorId,
				PatientTcKimlik = request.PatientTcKimlik,
				PatientId = request.PatientId,
				AppointmentDateTime = request.AppointmentDateTime

			});
		}
	}
}
