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
	public class RemovePatientCommandHandler : IRequestHandler<RemovePatientCommand>
	{
		private readonly IRepository<Patient> _repository;

		public RemovePatientCommandHandler(IRepository<Patient> repository)
		{
			_repository = repository;
		}

		public async Task Handle(RemovePatientCommand request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetByIdAsync(request.Id);
			await _repository.RemoveAsync(values); ;
		}
	}
}
