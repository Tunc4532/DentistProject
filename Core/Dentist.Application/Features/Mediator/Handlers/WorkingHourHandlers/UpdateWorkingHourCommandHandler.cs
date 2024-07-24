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
    public class UpdateWorkingHourCommandHandler : IRequestHandler<UpdateWorkingHourCommand>
    {
        private readonly IRepository<WorkingHour> _repository;

        public UpdateWorkingHourCommandHandler(IRepository<WorkingHour> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateWorkingHourCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.WorkingHourId);
            values.Hour = request.Hour;
            values.Day = request.Day;
            values.DoctorId = request.DoctorId;
            values.Phone = request.Phone;

            await _repository.UpdateAsync(values);
        }
    }
}
