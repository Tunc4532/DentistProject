using Dentist.Application.Features.Mediator.Commands.DoctorCommands;
using Dentist.Application.Interfaces;
using Dentist.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentist.Application.Features.Mediator.Handlers.DoctorHandlers
{
	public class RemoveDoctorCommandHandler : IRequestHandler<RemoveDoctorCommand>
	{
		private readonly IRepository<Doctor> _repository;

		public RemoveDoctorCommandHandler(IRepository<Doctor> repository)
		{
			_repository = repository;
		}

		public async Task Handle(RemoveDoctorCommand request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetByIdAsync(request.Id);
			await _repository.RemoveAsync(values);
		}
	}
}
