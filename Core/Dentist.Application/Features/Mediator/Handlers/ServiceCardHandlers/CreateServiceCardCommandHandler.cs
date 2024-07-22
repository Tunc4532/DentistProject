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
    public class CreateServiceCardCommandHandler : IRequestHandler<CreateServiceCardCommand>
    {
        private readonly IRepository<ServiceCard> _repository;

        public CreateServiceCardCommandHandler(IRepository<ServiceCard> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateServiceCardCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new ServiceCard
            {
                Description = request.Description,
                Image = request.Image,
                Title = request.Title,
            });
        }
    }
}
