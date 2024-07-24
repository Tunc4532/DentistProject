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
    public class CreateSkillCommandHandler : IRequestHandler<CreateSkillCommand>
    {
        private readonly IRepository<Skill> _repository;

        public CreateSkillCommandHandler(IRepository<Skill> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateSkillCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Skill
            {
                Talent = request.Talent,
                DoctorId = request.DoctorId,
            });
        }
    }
}
