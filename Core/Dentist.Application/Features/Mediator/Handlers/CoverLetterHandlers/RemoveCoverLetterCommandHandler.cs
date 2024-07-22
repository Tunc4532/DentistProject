using Dentist.Application.Features.Mediator.Commands.CoverLetterCommands;
using Dentist.Application.Interfaces;
using Dentist.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentist.Application.Features.Mediator.Handlers.CoverLetterHandlers
{
    public class RemoveCoverLetterCommandHandler : IRequestHandler<RemoveCoverLetterCommand>
    {
        private readonly IRepository<CoverLetter> _repository;

        public RemoveCoverLetterCommandHandler(IRepository<CoverLetter> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveCoverLetterCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            await _repository.RemoveAsync(values);
        }
    }
}
