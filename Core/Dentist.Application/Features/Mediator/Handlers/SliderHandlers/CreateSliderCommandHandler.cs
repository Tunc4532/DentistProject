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
    public class CreateSliderCommandHandler : IRequestHandler<CreateSliderCommand>
    {
        private readonly IRepository<Slider> _repository;

        public CreateSliderCommandHandler(IRepository<Slider> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateSliderCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Slider
            {
                Description = request.Description,
                Title1 = request.Title1,
                Title2 = request.Title2,
            });
        }
    }
}
