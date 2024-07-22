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
    public class GetCommentQueryHandler : IRequestHandler<GetCommentQuery, List<GetCommentQueryResult>>
    {
        private readonly IRepository<Comment> _repository;

        public GetCommentQueryHandler(IRepository<Comment> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCommentQueryResult>> Handle(GetCommentQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetCommentQueryResult
            {
                CommentId = x.CommentId,
                NameSurname = x.NameSurname,
                Title = x.Title,
                Image = x.Image,
                Description = x.Description,

            }).ToList();
        }
    }
}
