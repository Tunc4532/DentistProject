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
    public class GetServicePromotionByIdQueryHandler : IRequestHandler<GetServicePromotionByIdQuery, GetServicePromotionByIdQueryResult>
    {
        private readonly IRepository<ServicePromotion> _repository;

        public GetServicePromotionByIdQueryHandler(IRepository<ServicePromotion> repository)
        {
            _repository = repository;
        }

        public async Task<GetServicePromotionByIdQueryResult> Handle(GetServicePromotionByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetServicePromotionByIdQueryResult
            {
                ServicePromotionId = values.ServicePromotionId,
                Title = values.Title,
                Image1 = values.Image1,
                Description = values.Description,
                Image2 = values.Image2,
                Image3 = values.Image3,
            };
        }
    }
}
