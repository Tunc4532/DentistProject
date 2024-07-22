using Dentist.Application.Features.Mediator.Commands.ServiceCardCommands;
using Dentist.Application.Interfaces;
using Dentist.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentist.Application.Features.Mediator.Handlers.ServiceCardHandlers
{
    public class RemoveServiceCardCommandHandler : IRequestHandler<RemoveServiceCardCommand>
    {
        private readonly IRepository<ServiceCard> _repository;

        public RemoveServiceCardCommandHandler(IRepository<ServiceCard> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveServiceCardCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            await _repository.RemoveAsync(values);
        }
    }
}
