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
    public class UpdateCoverLetterCommandHandler : IRequestHandler<UpdateCoverLetterCommand>
    {
        private readonly IRepository<CoverLetter> _repository;

        public UpdateCoverLetterCommandHandler(IRepository<CoverLetter> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateCoverLetterCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.CoverLetterId);
            values.Description = request.Description;
            values.Title = request.Title;
            values.Image = request.Image;            

            await _repository.UpdateAsync(values);
        }
    }
}
