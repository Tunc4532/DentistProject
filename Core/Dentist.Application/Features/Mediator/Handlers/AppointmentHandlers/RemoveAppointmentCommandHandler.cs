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
	public class RemoveAppointmentCommandHandler : IRequestHandler<RemoveAppointmentCommand>
	{
		private readonly IRepository<Appointment> _repository;

		public RemoveAppointmentCommandHandler(IRepository<Appointment> repository)
		{
			_repository = repository;
		}

		public async Task Handle(RemoveAppointmentCommand request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetByIdAsync(request.Id);
			await _repository.RemoveAsync(values);
		}
	}
}
