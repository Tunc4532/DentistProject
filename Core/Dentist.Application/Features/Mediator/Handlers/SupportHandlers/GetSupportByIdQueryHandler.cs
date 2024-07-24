using Dentist.Application.Features.Mediator.Queries.SupportQueries;
using Dentist.Application.Features.Mediator.Results.SliderResults;
using Dentist.Application.Features.Mediator.Results.SupportResults;
using Dentist.Application.Interfaces;
using Dentist.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentist.Application.Features.Mediator.Handlers.SupportHandlers
{
    public class GetSupportByIdQueryHandler : IRequestHandler<GetSupportByIdQuery, GetSupportByIdQueryResult>
    {
        private readonly IRepository<Support> _repository;

        public GetSupportByIdQueryHandler(IRepository<Support> repository)
        {
            _repository = repository;
        }

        public async Task<GetSupportByIdQueryResult> Handle(GetSupportByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetSupportByIdQueryResult
            {
               Image = values.Image,
               SupportId = values.SupportId,
            };
        }
    }
}
