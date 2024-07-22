using Dentist.Application.Features.Mediator.Results.CoverLetterResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentist.Application.Features.Mediator.Queries.CoverLetterQueries
{
    public class GetCoverLetterQuery : IRequest<List<GetCoverLetterQueryResult>>
    {
    }
}
