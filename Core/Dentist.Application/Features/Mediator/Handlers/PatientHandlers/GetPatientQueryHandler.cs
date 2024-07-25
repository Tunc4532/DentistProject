using Dentist.Application.Features.Mediator.Queries.PatientQueries;
using Dentist.Application.Features.Mediator.Results.EducationResults;
using Dentist.Application.Features.Mediator.Results.PatientResults;
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
	public class GetPatientQueryHandler : IRequestHandler<GetPatientQuery, List<GetPatientQueryResult>>
	{
		private readonly IRepository<Patient> _repository;

		public GetPatientQueryHandler(IRepository<Patient> repository)
		{
			_repository = repository;
		}

		public async Task<List<GetPatientQueryResult>> Handle(GetPatientQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetAllAsync();
			return values.Select(x => new GetPatientQueryResult
			{
				Age = x.Age,
				Phone = x.Phone,
				UserId = x.UserId,
				PatientId = x.PatientId,
				NameSurname = x.NameSurname,
				TcKimlik = x.TcKimlik

			}).ToList();
		}
	}
}
