using Dentist.Application.Features.Mediator.Queries.DoctorQueries;
using Dentist.Application.Features.Mediator.Results.CoverLetterResults;
using Dentist.Application.Features.Mediator.Results.DoctorResults;
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
	public class GetDoctorByIdQueryHandler : IRequestHandler<GetDoctorByIdQuery, GetDoctorByIdQueryResult>
	{
		private readonly IRepository<Doctor> _repository;

		public GetDoctorByIdQueryHandler(IRepository<Doctor> repository)
		{
			_repository = repository;
		}

		public async Task<GetDoctorByIdQueryResult> Handle(GetDoctorByIdQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetByIdAsync(request.Id);
			return new GetDoctorByIdQueryResult
			{
				BirthDate = values.BirthDate,
				DoctorId = values.DoctorId,
				IsApproved = values.IsApproved,
				Address = values.Address,
				Image = values.Image,
				Name = values.Name,
				UserId = values.UserId,
				Surname = values.Surname
			};
		}
	}
}
