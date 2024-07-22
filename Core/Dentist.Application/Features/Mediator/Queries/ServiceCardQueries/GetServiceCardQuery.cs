using Dentist.Application.Features.Mediator.Results.ServiceCardResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentist.Application.Features.Mediator.Queries.ServiceCardQueries
{
    public class GetServiceCardQuery : IRequest<List<GetServiceCardQueryResult>>
    {
    }
}
