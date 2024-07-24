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
    public class GetEducationByIdQueryHandler : IRequestHandler<GetEducationByIdQuery, GetEducationByIdQueryResult>
    {
        private readonly IRepository<Education> _repository;

        public GetEducationByIdQueryHandler(IRepository<Education> repository)
        {
            _repository = repository;
        }

        public async Task<GetEducationByIdQueryResult> Handle(GetEducationByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetEducationByIdQueryResult
            {
                EducationId = values.EducationId,
                Description = values.Description,
                DoctorId = values.DoctorId,
                Year = values.Year,
                University = values.University
            };
        }
    }
}
