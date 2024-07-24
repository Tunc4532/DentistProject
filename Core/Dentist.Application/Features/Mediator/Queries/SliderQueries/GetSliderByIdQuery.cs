using Dentist.Application.Features.Mediator.Results.SliderResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentist.Application.Features.Mediator.Queries.SliderQueries
{
    public class GetSliderByIdQuery : IRequest<GetSliderByIdQueryResult>
    {
        public int Id { get; set; }

        public GetSliderByIdQuery(int id)
        {
            Id = id;
        }
    }
}
