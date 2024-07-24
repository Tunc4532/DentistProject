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
    public class GetSkillQueryHandler : IRequestHandler<GetSkillQuery,List<GetSkillQueryResult>>
    {
        private readonly IRepository<Skill> _repository;

        public GetSkillQueryHandler(IRepository<Skill> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetSkillQueryResult>> Handle(GetSkillQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetSkillQueryResult
            {
                SkillId = x.SkillId,
                DoctorId = x.DoctorId,
                Talent = x.Talent,

            }).ToList();
        }
    }
}
