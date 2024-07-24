using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentist.Application.Features.Mediator.Commands.WorkingHourCommands
{
    public class RemoveWorkingHourCommand : IRequest
    {
        public int Id { get; set; }

        public RemoveWorkingHourCommand(int id)
        {
            Id = id;
        }
    }
}
