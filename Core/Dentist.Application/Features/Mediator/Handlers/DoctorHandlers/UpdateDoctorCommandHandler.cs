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
	public class UpdateDoctorCommandHandler : IRequestHandler<UpdateDoctorCommand>
	{
		private readonly IRepository<Doctor> _repository;

		public UpdateDoctorCommandHandler(IRepository<Doctor> repository)
		{
			_repository = repository;
		}

		public async Task Handle(UpdateDoctorCommand request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetByIdAsync(request.DoctorId);
			values.Surname = request.Surname;
			values.Address = request.Address;
			values.BirthDate = request.BirthDate;
			values.UserId = request.UserId;
			values.Name = request.Name;
			values.Image = request.Image;
			values.IsApproved = request.IsApproved;

			await _repository.UpdateAsync(values);
		}
	}
}
