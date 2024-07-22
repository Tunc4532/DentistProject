using Dentist.Application.Features.Mediator.Results.CommentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentist.Application.Features.Mediator.Queries.CommentQueries
{
    public class GetCommentQuery : IRequest<List<GetCommentQueryResult>>
    {
    }
}
