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
    public class GetSupportQueryHandler : IRequestHandler<GetSupportQuery, List<GetSupportQueryResult>>
    {
        private readonly IRepository<Support> _repository;

        public GetSupportQueryHandler(IRepository<Support> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetSupportQueryResult>> Handle(GetSupportQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetSupportQueryResult
            {
                Image = x.Image,

            }).ToList();
        }
    }
}
