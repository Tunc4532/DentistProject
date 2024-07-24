using Dentist.Application.Features.Mediator.Queries.EducationQueries;
using Dentist.Application.Features.Mediator.Results.CoverLetterResults;
using Dentist.Application.Features.Mediator.Results.EducationResults;
using Dentist.Application.Interfaces;
using Dentist.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentist.Application.Features.Mediator.Handlers.EducationHandlers
{
    public class GetEducationQueryHandler : IRequestHandler<GetEducationQuery,List<GetEducationQueryResult>>
    {
        private readonly IRepository<Education> _repository;

        public GetEducationQueryHandler(IRepository<Education> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetEducationQueryResult>> Handle(GetEducationQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetEducationQueryResult
            {
                EducationId = x.EducationId,
                DoctorId = x.DoctorId,
                Year = x.Year,
                University = x.University,
                Description = x.Description

            }).ToList();
        }
    }
}
