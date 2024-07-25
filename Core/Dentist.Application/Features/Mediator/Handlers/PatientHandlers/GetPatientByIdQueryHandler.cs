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
	public class GetPatientByIdQueryHandler : IRequestHandler<GetPatientByIdQuery, GetPatientByIdQueryResult>
	{
		private readonly IRepository<Patient> _repository;

		public GetPatientByIdQueryHandler(IRepository<Patient> repository)
		{
			_repository = repository;
		}

		public async Task<GetPatientByIdQueryResult> Handle(GetPatientByIdQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetByIdAsync(request.Id);
			return new GetPatientByIdQueryResult
			{
				PatientId = values.PatientId,
				UserId = values.UserId,
				Age = values.Age,
				NameSurname = values.NameSurname,
				TcKimlik = values.TcKimlik,
				Phone = values.Phone
			};
		}
	}
}
