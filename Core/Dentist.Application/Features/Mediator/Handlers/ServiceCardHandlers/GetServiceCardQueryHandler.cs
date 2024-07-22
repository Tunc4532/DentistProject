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
    public class GetServiceCardQueryHandler : IRequestHandler<GetServiceCardQuery, List<GetServiceCardQueryResult>>
    {
        private readonly IRepository<ServiceCard> _repository;

        public GetServiceCardQueryHandler(IRepository<ServiceCard> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetServiceCardQueryResult>> Handle(GetServiceCardQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetServiceCardQueryResult
            {
                ServiceCardId = x.ServiceCardId,
                Description = x.Description,
                Image = x.Image,
                Title = x.Title

            }).ToList();
        }
    }
}
