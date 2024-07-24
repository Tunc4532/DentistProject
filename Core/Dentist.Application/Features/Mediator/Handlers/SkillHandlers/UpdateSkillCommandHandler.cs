using Dentist.Application.Features.Mediator.Commands.SkillCommands;
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
    public class UpdateSkillCommandHandler : IRequestHandler<UpdateSkillCommand>
    {
        private readonly IRepository<Skill> _repository;

        public UpdateSkillCommandHandler(IRepository<Skill> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateSkillCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.SkillId);
            values.Talent = request.Talent;
            values.DoctorId = request.DoctorId;

            await _repository.UpdateAsync(values);
        }
    }
}
