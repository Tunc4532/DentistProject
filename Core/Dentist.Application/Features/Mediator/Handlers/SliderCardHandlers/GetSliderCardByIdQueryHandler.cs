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
    public class GetSliderCardByIdQueryHandler : IRequestHandler<GetSliderCardByIdQuery, GetSliderCardByIdQueryResult>
    {
        private readonly IRepository<SliderCard> _repository;

        public GetSliderCardByIdQueryHandler(IRepository<SliderCard> repository)
        {
            _repository = repository;
        }

        public async Task<GetSliderCardByIdQueryResult> Handle(GetSliderCardByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetSliderCardByIdQueryResult
            {
                SliderCardId = values.SliderCardId,
                Icon = values.Icon,
                Title = values.Title,
                Subtitle = values.Subtitle,
                Description = values.Description,
                Icon2 = values.Icon2,
                Title2 = values.Title2,
                Subtitle2 = values.Subtitle2,
                day1 = values.day1,
                day2 = values.day2,
                day3 = values.day3,
                Hour1 = values.Hour1,
                Hour2 = values.Hour2,
                Hour3 = values.Hour3,
                Icon3 = values.Icon3,
                Title3 = values.Title3,
                Subtitle3 = values.Subtitle3,
                Description3 = values.Description3,
            };
        }
    }
}
