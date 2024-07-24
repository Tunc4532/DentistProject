using Dentist.Application.Features.Mediator.Results.SliderCardResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentist.Application.Features.Mediator.Queries.SliderCardQueries
{
    public class GetSliderCardByIdQuery : IRequest<GetSliderCardByIdQueryResult>
    {
        public int Id { get; set; }

        public GetSliderCardByIdQuery(int ıd)
        {
            Id = ıd;
        }
    }
}
