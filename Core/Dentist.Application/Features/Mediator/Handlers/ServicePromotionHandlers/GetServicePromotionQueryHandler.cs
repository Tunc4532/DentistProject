using Dentist.Application.Features.Mediator.Queries.ServicePromotionQueries;
using Dentist.Application.Features.Mediator.Results.ServiceCardResults;
using Dentist.Application.Features.Mediator.Results.ServicePromotionResults;
using Dentist.Application.Interfaces;
using Dentist.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentist.Application.Features.Mediator.Handlers.ServicePromotionHandlers
{
    public class GetServicePromotionQueryHandler : IRequestHandler<GetServicePromotionQuery, List<GetServicePromotionQueryResult>>
    {
        private readonly IRepository<ServicePromotion> _repository;

        public GetServicePromotionQueryHandler(IRepository<ServicePromotion> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetServicePromotionQueryResult>> Handle(GetServicePromotionQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetServicePromotionQueryResult
            {
                ServicePromotionId = x.ServicePromotionId,
                Description = x.Description,
                Image1 = x.Image1,
                Title = x.Title,
                Image2 = x.Image2,
                Image3 = x.Image3,

            }).ToList();
        }
    }
}
