using Dentist.Application.Features.Mediator.Results.EducationResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentist.Application.Features.Mediator.Queries.EducationQueries
{
    public class GetEducationQuery : IRequest<List<GetEducationQueryResult>>
    {
    }
}
