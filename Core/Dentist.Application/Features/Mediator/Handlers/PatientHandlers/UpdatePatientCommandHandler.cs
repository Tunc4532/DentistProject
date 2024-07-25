using Dentist.Application.Features.Mediator.Commands.PatientCommands;
using Dentist.Application.Interfaces;
using Dentist.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentist.Application.Features.Mediator.Handlers.PatientHandlers
{
	public class UpdatePatientCommandHandler : IRequestHandler<UpdatePatientCommand>
	{
		private readonly IRepository<Patient> _repository;

		public UpdatePatientCommandHandler(IRepository<Patient> repository)
		{
			_repository = repository;
		}

		public async Task Handle(UpdatePatientCommand request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetByIdAsync(request.PatientId);
			values.NameSurname = request.NameSurname;
			values.TcKimlik = request.TcKimlik;
			values.Age = request.Age;
			values.UserId = request.UserId;
			values.Phone = request.Phone;

			await _repository.UpdateAsync(values);
		}
	}
}
