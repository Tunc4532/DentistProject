using Dentist.Application.Features.Mediator.Commands.WorkingHourCommands;
using Dentist.Application.Interfaces;
using Dentist.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentist.Application.Features.Mediator.Handlers.WorkingHourHandlers
{
    public class RemoveWorkingHourCommandHandler : IRequestHandler<RemoveWorkingHourCommand>
    {
        private readonly IRepository<WorkingHour> _repository;

        public RemoveWorkingHourCommandHandler(IRepository<WorkingHour> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveWorkingHourCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            await _repository.RemoveAsync(values);
        }
    }
}
