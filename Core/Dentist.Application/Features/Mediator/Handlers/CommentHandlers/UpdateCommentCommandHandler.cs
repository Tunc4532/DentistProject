using Dentist.Application.Features.Mediator.Commands.CommentCommands;
using Dentist.Application.Interfaces;
using Dentist.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentist.Application.Features.Mediator.Handlers.CommentHandlers
{
    public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand>
    {
        private readonly IRepository<Comment> _repository;

        public UpdateCommentCommandHandler(IRepository<Comment> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.CommentId);
            values.NameSurname = request.NameSurname;
            values.Title = request.Title;
            values.Description = request.Description;
            values.Image = request.Image;

            await _repository.UpdateAsync(values);
        }
    }
}
