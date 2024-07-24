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
    public class CreateWorkingHourCommandHandler : IRequestHandler<CreateWorkingHourCommand>
    {
        private readonly IRepository<WorkingHour> _repository;

        public CreateWorkingHourCommandHandler(IRepository<WorkingHour> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateWorkingHourCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new WorkingHour
            {
               Day = request.Day,
               Phone = request.Phone,
               Hour = request.Hour,
               DoctorId = request.DoctorId,
            });
        }
    }
}
