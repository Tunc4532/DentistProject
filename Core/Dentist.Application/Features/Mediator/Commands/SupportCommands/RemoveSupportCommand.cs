using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentist.Application.Features.Mediator.Commands.SupportCommands
{
    public class RemoveSupportCommand : IRequest
    {
        public int Id { get; set; }

        public RemoveSupportCommand(int id)
        {
            Id = id;
        }
    }
}
