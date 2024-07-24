using Dentist.Application.Features.Mediator.Commands.SliderCommands;
using Dentist.Application.Interfaces;
using Dentist.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentist.Application.Features.Mediator.Handlers.SliderHandlers
{
    public class RemoveSliderCommandHandler : IRequestHandler<RemoveSliderCommand>
    {
        private readonly IRepository<Slider> _repository;

        public RemoveSliderCommandHandler(IRepository<Slider> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveSliderCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            await _repository.RemoveAsync(values);
        }
    }
}
