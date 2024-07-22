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
    public class UpdateServiceCardCommandHandler : IRequestHandler<UpdateServiceCardCommand>
    {
        private readonly IRepository<ServiceCard> _repository;

        public UpdateServiceCardCommandHandler(IRepository<ServiceCard> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateServiceCardCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.ServiceCardId);
            values.Description = request.Description;
            values.Title = request.Title;
            values.Image = request.Image;

            await _repository.UpdateAsync(values);
        }
    }
}
