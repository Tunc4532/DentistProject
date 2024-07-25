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
	public class UpdateAppointmentCommandHandler : IRequestHandler<UpdateAppointmentCommand>
	{
		private readonly IRepository<Appointment> _repository;

		public UpdateAppointmentCommandHandler(IRepository<Appointment> repository)
		{
			_repository = repository;
		}

		public async Task Handle(UpdateAppointmentCommand request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetByIdAsync(request.AppointmentId);
			values.AppointmentDateTime = request.AppointmentDateTime;
			values.DoctorId = request.AppointmentId;
			values.PatientId = request.PatientId;
			values.IsAvailable = request.IsAvailable;
			values.PatientTcKimlik = request.PatientTcKimlik;

			await _repository.UpdateAsync(values);
		}
	}
}
