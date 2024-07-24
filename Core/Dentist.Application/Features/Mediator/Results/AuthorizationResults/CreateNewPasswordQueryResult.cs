using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentist.Application.Features.Mediator.Results.AuthorizationResults
{
    public class CreateNewPasswordQueryResult
    {
        public string NewPassword { get; set; }
        public string Message { get; set; }
    }
}
