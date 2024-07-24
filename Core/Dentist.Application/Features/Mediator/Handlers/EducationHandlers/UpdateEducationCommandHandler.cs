using Dentist.Application.Features.Mediator.Commands.EducationCommands;
using Dentist.Application.Interfaces;
using Dentist.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentist.Application.Features.Mediator.Handlers.EducationHandlers
{
    public class UpdateEducationCommandHandler : IRequestHandler<UpdateEducationCommand>
    {
        private readonly IRepository<Education> _repository;

        public UpdateEducationCommandHandler(IRepository<Education> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateEducationCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.EducationId);
            values.Description = request.Description;
            values.University = request.University;
            values.Year = request.Year;
            values.DoctorId = request.DoctorId;

            await _repository.UpdateAsync(values);
        }
    }
}
