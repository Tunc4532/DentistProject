using Dentist.Application.Features.Mediator.Results.AuthorizationResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentist.Application.Features.Mediator.Queries.AuthorizationQueries
{
    public class ResetPasswordQuery : IRequest<ResetPasswordQueryResult>
    {
        public string Username { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
