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
    public class CreateEducationCommandHandler : IRequestHandler<CreateEducationCommand>
    {
        private readonly IRepository<Education> _repository;

        public CreateEducationCommandHandler(IRepository<Education> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateEducationCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Education
            {
                Description = request.Description,
                University = request.University,
                Year = request.Year,
                DoctorId = request.DoctorId,
            });
        }
    }
}
