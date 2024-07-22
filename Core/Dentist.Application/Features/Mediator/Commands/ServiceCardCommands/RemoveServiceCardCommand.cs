using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentist.Application.Features.Mediator.Commands.ServiceCardCommands
{
    public class RemoveServiceCardCommand : IRequest
    {
        public int Id { get; set; }

        public RemoveServiceCardCommand(int id)
        {
            Id = id;
        }
    }
}
