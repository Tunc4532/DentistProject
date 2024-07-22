using Dentist.Application.Features.Mediator.Results.CommentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentist.Application.Features.Mediator.Queries.CommentQueries
{
    public class GetCommentByIdQuery : IRequest<GetCommentByIdQueryResult>
    {
        public int Id { get; set; }

        public GetCommentByIdQuery(int id)
        {
            Id = id;
        }
    }
}
