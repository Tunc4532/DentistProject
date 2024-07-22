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
    public class CreateCoverLetterCommandHandler : IRequestHandler<CreateCoverLetterCommand>
    {
        private readonly IRepository<CoverLetter> _repository;

        public CreateCoverLetterCommandHandler(IRepository<CoverLetter> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateCoverLetterCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new CoverLetter
            {
                Description = request.Description,
                Image = request.Image,
                Title = request.Title,
            });
        }
    }
}
