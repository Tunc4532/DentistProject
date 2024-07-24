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
    public class CreateServicePromotionCommandHandler : IRequestHandler<CreateServicePromotionCommand>
    {
        private readonly IRepository<ServicePromotion> _repository;

        public CreateServicePromotionCommandHandler(IRepository<ServicePromotion> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateServicePromotionCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new ServicePromotion
            {
                Description = request.Description,
                Image1 = request.Image1,
                Title = request.Title,
                Image2 = request.Image2,
                Image3 = request.Image3,
            });
        }
    }
}
