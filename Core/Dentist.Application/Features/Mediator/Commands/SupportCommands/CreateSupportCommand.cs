using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentist.Application.Features.Mediator.Commands.SupportCommands
{
    public class CreateSupportCommand : IRequest
    {
        public string Image { get; set; }
    }
}
