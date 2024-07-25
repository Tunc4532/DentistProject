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
	public class CreatePatientCommandHandler : IRequestHandler<CreatePatientCommand>
	{
		private readonly IRepository<Patient> _repository;

		public CreatePatientCommandHandler(IRepository<Patient> repository)
		{
			_repository = repository;
		}

		public async Task Handle(CreatePatientCommand request, CancellationToken cancellationToken)
		{
			await _repository.CreateAsync(new Patient
			{
				Age = request.Age,
				Phone = request.Phone,
				UserId = request.UserId,
				NameSurname = request.NameSurname,
				TcKimlik = request.TcKimlik,

			});
		}
	}
}
