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
    public class UpdateSliderCommandHandler : IRequestHandler<UpdateSliderCommand>
    {
        private readonly IRepository<Slider> _repository;

        public UpdateSliderCommandHandler(IRepository<Slider> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateSliderCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.SliderId);
            values.Description = request.Description;
            values.Title1 = request.Title1;
            values.Title2 = request.Title2;

            await _repository.UpdateAsync(values);
        }
    }
}
