using Dentist.Application.Features.Mediator.Results.PatientResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentist.Application.Features.Mediator.Queries.PatientQueries
{
	public class GetPatientQuery : IRequest<List<GetPatientQueryResult>>
	{
	}
}
