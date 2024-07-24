using Dentist.Application.Features.Mediator.Commands.SliderCardCommands;
using Dentist.Application.Interfaces;
using Dentist.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentist.Application.Features.Mediator.Handlers.SliderCardHandlers
{
    public class RemoveSliderCardCommandHandler : IRequestHandler<RemoveSliderCardCommand>
    {
        private readonly IRepository<SliderCard> _repository;

        public RemoveSliderCardCommandHandler(IRepository<SliderCard> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveSliderCardCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            await _repository.RemoveAsync(values);
        }
    }
}
