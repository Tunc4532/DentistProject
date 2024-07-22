using Dentist.Application.Features.Mediator.Commands.AboutCommands;
using Dentist.Application.Interfaces;
using Dentist.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentist.Application.Features.Mediator.Handlers.AboutHandlers
{
    public class UpdateAboutCommandHandler : IRequestHandler<UpdateAboutCommand>
    {
        private readonly IRepository<About> _repository;

        public UpdateAboutCommandHandler(IRepository<About> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateAboutCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.AboutId);
            values.Title = request.Title;
            values.Name = request.Name;
            values.Description = request.Description;

            await _repository.UpdateAsync(values);
        }
    }
}
