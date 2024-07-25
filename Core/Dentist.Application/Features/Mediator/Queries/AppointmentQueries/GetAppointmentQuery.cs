using Dentist.Application.Features.Mediator.Results.AppointmentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentist.Application.Features.Mediator.Queries.AppointmentQueries
{
	public class GetAppointmentQuery : IRequest<List<GetAppointmentQueryResult>>
	{
	}
}
