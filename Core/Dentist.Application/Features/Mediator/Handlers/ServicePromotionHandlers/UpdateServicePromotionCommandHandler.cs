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
    public class UpdateServicePromotionCommandHandler : IRequestHandler<UpdateServicePromotionCommand>
    {
        private readonly IRepository<ServicePromotion> _repository;

        public UpdateServicePromotionCommandHandler(IRepository<ServicePromotion> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateServicePromotionCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.ServicePromotionId);
            values.Description = request.Description;
            values.Title = request.Title;
            values.Image1 = request.Image1;
            values.Image2 = request.Image2;
            values.Image3 = request.Image3;

            await _repository.UpdateAsync(values);
        }
    }
}
