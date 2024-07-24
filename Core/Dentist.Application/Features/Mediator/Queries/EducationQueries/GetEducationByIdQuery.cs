using Dentist.Application.Features.Mediator.Results.EducationResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentist.Application.Features.Mediator.Queries.EducationQueries
{
    public class GetEducationByIdQuery : IRequest<GetEducationByIdQueryResult>
    {
        public int Id { get; set; }

        public GetEducationByIdQuery(int id)
        {
            Id = id;
        }
    }
}
