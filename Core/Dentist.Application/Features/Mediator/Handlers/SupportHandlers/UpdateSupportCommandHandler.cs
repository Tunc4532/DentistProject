using Dentist.Application.Features.Mediator.Commands.SupportCommands;
using Dentist.Application.Interfaces;
using Dentist.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentist.Application.Features.Mediator.Handlers.SupportHandlers
{
    public class UpdateSupportCommandHandler : IRequestHandler<UpdateSupportCommand>
    {
        private readonly IRepository<Support> _repository;

        public UpdateSupportCommandHandler(IRepository<Support> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateSupportCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.SupportId);
            values.Image = request.Image;

            await _repository.UpdateAsync(values);
        }
    }
}
