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
	public class CreateDoctorCommandHandler : IRequestHandler<CreateDoctorCommand>
	{
		private readonly IRepository<Doctor> _repository;

		public CreateDoctorCommandHandler(IRepository<Doctor> repository)
		{
			_repository = repository;
		}

		public async Task Handle(CreateDoctorCommand request, CancellationToken cancellationToken)
		{
			await _repository.CreateAsync(new Doctor
			{
				IsApproved = request.IsApproved,
				Image = request.Image,
				Name = request.Name,
				UserId = request.UserId,
				BirthDate = request.BirthDate,
				Address = request.Address,
				Surname = request.Surname,
				
			});
		}
	}
}
