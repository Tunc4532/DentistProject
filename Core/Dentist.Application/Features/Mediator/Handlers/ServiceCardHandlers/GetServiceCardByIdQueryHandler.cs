using Dentist.Application.Features.Mediator.Queries.ServiceCardQueries;
using Dentist.Application.Features.Mediator.Results.CoverLetterResults;
using Dentist.Application.Features.Mediator.Results.ServiceCardResults;
using Dentist.Application.Interfaces;
using Dentist.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentist.Application.Features.Mediator.Handlers.ServiceCardHandlers
{
    public class GetServiceCardByIdQueryHandler : IRequestHandler<GetServiceCardByIdQuery, GetServiceCardByIdQueryResult>
    {
        private readonly IRepository<ServiceCard> _repository;

        public GetServiceCardByIdQueryHandler(IRepository<ServiceCard> repository)
        {
            _repository = repository;
        }

        public async Task<GetServiceCardByIdQueryResult> Handle(GetServiceCardByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetServiceCardByIdQueryResult
            {
                ServiceCardId = values.ServiceCardId,
                Title = values.Title,
                Image = values.Image,
                Description = values.Description,
            };
        }
    }
}
