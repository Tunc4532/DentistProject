using Dentist.Application.Features.Mediator.Queries.SliderQueries;
using Dentist.Application.Features.Mediator.Results.ServicePromotionResults;
using Dentist.Application.Features.Mediator.Results.SliderResults;
using Dentist.Application.Interfaces;
using Dentist.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentist.Application.Features.Mediator.Handlers.SliderHandlers
{
    public class GetSliderByIdQueryHandler : IRequestHandler<GetSliderByIdQuery, GetSliderByIdQueryResult>
    {
        private readonly IRepository<Slider> _repository;

        public GetSliderByIdQueryHandler(IRepository<Slider> repository)
        {
            _repository = repository;
        }

        public async Task<GetSliderByIdQueryResult> Handle(GetSliderByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetSliderByIdQueryResult
            {
                SliderId = values.SliderId,
                Description = values.Description,
                Title1 = values.Title1,
                Title2 = values.Title2,
            };
        }
    }
}
