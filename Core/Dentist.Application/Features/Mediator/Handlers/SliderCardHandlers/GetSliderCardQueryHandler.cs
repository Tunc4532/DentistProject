using Dentist.Application.Features.Mediator.Queries.SliderCardQueries;
using Dentist.Application.Features.Mediator.Results.SliderCardResults;
using Dentist.Application.Features.Mediator.Results.SliderResults;
using Dentist.Application.Interfaces;
using Dentist.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentist.Application.Features.Mediator.Handlers.SliderCardHandlers
{
    public class GetSliderCardQueryHandler : IRequestHandler<GetSliderCardQuery, List<GetSliderCardQueryResult>>
    {
        private readonly IRepository<SliderCard> _repository;

        public GetSliderCardQueryHandler(IRepository<SliderCard> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetSliderCardQueryResult>> Handle(GetSliderCardQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetSliderCardQueryResult
            {
                SliderCardId = x.SliderCardId,
                Icon = x.Icon,
                Title = x.Title,
                Subtitle = x.Subtitle,
                Description = x.Description,
                Icon2 = x.Icon2,
                Title2 = x.Title2,
                Subtitle2 = x.Subtitle2,
                day1 = x.day1,
                day2 = x.day2,
                day3 = x.day3,
                Hour1 = x.Hour1,
                Hour2 = x.Hour2,
                Hour3 = x.Hour3,
                Icon3 = x.Icon3,
                Title3 = x.Title3,
                Subtitle3 = x.Subtitle3,
                Description3 = x.Description3,

            }).ToList();
        }
    }
}
