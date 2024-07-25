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
	public class GetDoctorQueryHandler : IRequestHandler<GetDoctorQuery, List<GetDoctorQueryResult>>
	{
		private readonly IRepository<Doctor> _repository;

		public GetDoctorQueryHandler(IRepository<Doctor> repository)
		{
			_repository = repository;
		}

		public async Task<List<GetDoctorQueryResult>> Handle(GetDoctorQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetAllAsync();
			return values.Select(x => new GetDoctorQueryResult
			{
				Surname = x.Surname,
				Address = x.Address,
				BirthDate = x.BirthDate,
				UserId = x.UserId,
				Name = x.Name,
				Image = x.Image,
				IsApproved = x.IsApproved,
				DoctorId = x.DoctorId

			}).ToList();
		}
	}
}
