using Dentist.Application.Features.Mediator.Results.AuthorizationResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentist.Application.Features.Mediator.Queries.AuthorizationQueries
{
    public class CreateNewPasswordQuery : IRequest<CreateNewPasswordQueryResult>
    {
        public string Username { get; set; }
    }
}
