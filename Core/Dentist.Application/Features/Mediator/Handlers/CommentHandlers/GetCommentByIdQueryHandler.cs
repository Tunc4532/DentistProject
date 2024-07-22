using Dentist.Application.Features.Mediator.Queries.CommentQueries;
using Dentist.Application.Features.Mediator.Results.CommentResults;
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
    public class GetCommentByIdQueryHandler : IRequestHandler<GetCommentByIdQuery, GetCommentByIdQueryResult>
    {
        private readonly IRepository<Comment> _repository;

        public GetCommentByIdQueryHandler(IRepository<Comment> repository)
        {
            _repository = repository;
        }

        public async Task<GetCommentByIdQueryResult> Handle(GetCommentByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetCommentByIdQueryResult
            {
                CommentId = values.CommentId,
                NameSurname = values.NameSurname,
                Title = values.Title,
                Image = values.Image,
                Description = values.Description,
            };
        }
    }
}
