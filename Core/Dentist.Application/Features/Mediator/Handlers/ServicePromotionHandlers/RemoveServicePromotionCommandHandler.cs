using Dentist.Application.Features.Mediator.Commands.ServicePromotionCommands;
using Dentist.Application.Interfaces;
using Dentist.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentist.Application.Features.Mediator.Handlers.ServicePromotionHandlers
{
    public class RemoveServicePromotionCommandHandler : IRequestHandler<RemoveServicePromotionCommand>
    {
        private readonly IRepository<ServicePromotion> _repository;

        public RemoveServicePromotionCommandHandler(IRepository<ServicePromotion> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveServicePromotionCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            await _repository.RemoveAsync(values);
        }
    }
}
