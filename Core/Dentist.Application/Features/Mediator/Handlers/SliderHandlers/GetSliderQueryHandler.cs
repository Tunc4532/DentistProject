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
    public class GetSliderQueryHandler : IRequestHandler<GetSliderQuery, List<GetSliderQueryResult>>
    {
        private readonly IRepository<Slider> _repository;

        public GetSliderQueryHandler(IRepository<Slider> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetSliderQueryResult>> Handle(GetSliderQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetSliderQueryResult
            {
                SliderId = x.SliderId,
                Description = x.Description,
                Title1 = x.Title1,
                Title2 = x.Title2,

            }).ToList();
        }
    }
}
