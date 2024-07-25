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
	public class GetAppointmentByIdQueryHandler : IRequestHandler<GetAppointmentByIdQuery, GetAppointmentByIdQueryResult>
	{
		private readonly IRepository<Appointment> _repository;

		public GetAppointmentByIdQueryHandler(IRepository<Appointment> repository)
		{
			_repository = repository;
		}

		public async Task<GetAppointmentByIdQueryResult> Handle(GetAppointmentByIdQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetByIdAsync(request.Id);
			return new GetAppointmentByIdQueryResult
			{
				AppointmentDateTime = values.AppointmentDateTime,
				AppointmentId = values.AppointmentId,
				PatientId = values.PatientId,
				PatientTcKimlik = values.PatientTcKimlik,
				DoctorId = values.DoctorId,
				IsAvailable = values.IsAvailable
			};
		}
	}
}
