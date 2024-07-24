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
    public class RemoveSkillCommandHandler : IRequestHandler<RemoveSkillCommand>
    {
        private readonly IRepository<Skill> _repository;

        public RemoveSkillCommandHandler(IRepository<Skill> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveSkillCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            await _repository.RemoveAsync(values);
        }
    }
}
