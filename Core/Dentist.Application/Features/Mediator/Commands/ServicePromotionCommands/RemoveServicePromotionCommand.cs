using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentist.Application.Features.Mediator.Commands.ServicePromotionCommands
{
    public class RemoveServicePromotionCommand : IRequest
    {
        public int Id { get; set; }

        public RemoveServicePromotionCommand(int id)
        {
            Id = id;
        }
    }
}
