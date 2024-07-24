using Dentist.Application.Features.Mediator.Queries.SkillQueries;
using Dentist.Application.Features.Mediator.Results.ServicePromotionResults;
using Dentist.Application.Features.Mediator.Results.SkillResults;
using Dentist.Application.Interfaces;
using Dentist.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentist.Application.Features.Mediator.Handlers.SkillHandlers
{
    public class GetSkillByIdQueryHandler : IRequestHandler<GetSkillByIdQuery, GetSkillByIdQueryResult>
    {
        private readonly IRepository<Skill> _repository;

        public GetSkillByIdQueryHandler(IRepository<Skill> repository)
        {
            _repository = repository;
        }

        public async Task<GetSkillByIdQueryResult> Handle(GetSkillByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetSkillByIdQueryResult
            {
                DoctorId = values.DoctorId,
                SkillId = values.SkillId,
                Talent = values.Talent,
            };
        }
    }
}
