using Dentist.Application.Features.Mediator.Commands.SupportCommands;
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
    public class RemoveSupportCommandHandler : IRequestHandler<RemoveSupportCommand>
    {
        private readonly IRepository<Support> _repository;

        public RemoveSupportCommandHandler(IRepository<Support> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveSupportCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            await _repository.RemoveAsync(values);
        }
    }
}
