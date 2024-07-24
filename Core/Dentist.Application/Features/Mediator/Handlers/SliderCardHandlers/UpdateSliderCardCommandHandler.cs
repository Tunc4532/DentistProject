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
    public class UpdateSliderCardCommandHandler : IRequestHandler<UpdateSliderCardCommand>
    {
        private readonly IRepository<SliderCard> _repository;

        public UpdateSliderCardCommandHandler(IRepository<SliderCard> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateSliderCardCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.SliderCardId);
            values.Icon = request.Icon;
            values.Title = request.Title;
            values.Subtitle = request.Subtitle;
            values.Description = request.Description;
            values.Icon2 = request.Icon2;
            values.Title2 = request.Title2;
            values.Subtitle2 = request.Subtitle2;
            values.day1 = request.day1;
            values.day2 = request.day2;
            values.day3 = request.day3;
            values.Hour1 = request.Hour1;
            values.Hour2 = request.Hour2;
            values.Hour3 = request.Hour3;
            values.Icon3 = request.Icon3;
            values.Title3 = request.Title3;
            values.Subtitle3 = request.Subtitle3;
            values.Description3 = request.Description3;

            await _repository.UpdateAsync(values);
        }
    }
}
