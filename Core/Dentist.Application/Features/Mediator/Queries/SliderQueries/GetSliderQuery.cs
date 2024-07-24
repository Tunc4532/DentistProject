using Dentist.Application.Features.Mediator.Results.SliderResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentist.Application.Features.Mediator.Queries.SliderQueries
{
    public class GetSliderQuery : IRequest<List<GetSliderQueryResult>>
    {
    }
}
