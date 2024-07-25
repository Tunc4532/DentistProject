using Dentist.Application.Features.Mediator.Queries.AppointmentQueries;
using Dentist.Application.Features.Mediator.Results.AboutResults;
using Dentist.Application.Features.Mediator.Results.AppointmentResults;
using Dentist.Application.Interfaces;
using Dentist.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentist.Application.Features.Mediator.Handlers.AppointmentHandlers
{
	public class GetAppointmentQueryHandler : IRequestHandler<GetAppointmentQuery, List<GetAppointmentQueryResult>>
	{
		private readonly IRepository<Appointment> _repository;

		public GetAppointmentQueryHandler(IRepository<Appointment> repository)
		{
			_repository = repository;
		}

		public async Task<List<GetAppointmentQueryResult>> Handle(GetAppointmentQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetAllAsync();
			return values.Select(x => new GetAppointmentQueryResult
			{
				PatientId = x.PatientId,
				AppointmentId = x.AppointmentId,
				DoctorId = x.DoctorId,
				IsAvailable = x.IsAvailable,
				AppointmentDateTime = x.AppointmentDateTime,
				PatientTcKimlik = x.PatientTcKimlik	

			}).ToList();
		}
	}
}
