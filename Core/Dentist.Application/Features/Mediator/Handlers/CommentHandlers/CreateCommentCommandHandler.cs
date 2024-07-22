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
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand>
    {
        private readonly IRepository<Comment> _repository;

        public CreateCommentCommandHandler(IRepository<Comment> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Comment
            {
                Description = request.Description,
                Image = request.Image,
                NameSurname = request.NameSurname,
                Title = request.Title,
            });
        }
    }
}
