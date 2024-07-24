using Dentist.Application.Features.Mediator.Results.SupportResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentist.Application.Features.Mediator.Queries.SupportQueries
{
    public class GetSupportByIdQuery : IRequest<GetSupportByIdQueryResult>
    {
        public int Id { get; set; }

        public GetSupportByIdQuery(int id)
        {
            Id = id;
        }
    }
}
