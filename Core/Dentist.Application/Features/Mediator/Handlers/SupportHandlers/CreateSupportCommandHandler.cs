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
    public class CreateSupportCommandHandler : IRequestHandler<CreateSupportCommand>
    {
        private readonly IRepository<Support> _repository;

        public CreateSupportCommandHandler(IRepository<Support> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateSupportCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Support
            {
              Image = request.Image,
            });
        }
    }
}
