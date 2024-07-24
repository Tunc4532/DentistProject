using Dentist.Application.Features.Mediator.Commands.EducationCommands;
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
    public class RemoveEducationCommandHandler : IRequestHandler<RemoveEducationCommand>
    {
        private readonly IRepository<Education> _repository;

        public RemoveEducationCommandHandler(IRepository<Education> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveEducationCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            await _repository.RemoveAsync(values);
        }
    }
}
