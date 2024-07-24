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
    public class CreateSliderCardCommandHandler : IRequestHandler<CreateSliderCardCommand>
    {
        private readonly IRepository<SliderCard> _repository;

        public CreateSliderCardCommandHandler(IRepository<SliderCard> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateSliderCardCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new SliderCard
            {
                Icon = request.Icon,
                Title = request.Title,
                Subtitle = request.Subtitle,
                Description = request.Description,
                Icon2 = request.Icon2,
                Title2 = request.Title2,
                Subtitle2 = request.Subtitle2,
                day1 = request.day1,
                day2 = request.day2,
                day3 = request.day3,
                Hour1 = request.Hour1,
                Hour2 = request.Hour2,
                Hour3 = request.Hour3,
                Icon3 = request.Icon3,
                Title3 = request.Title3,
                Subtitle3 = request.Subtitle3,
                Description3 = request.Description3,
            });
        }
    }
}
