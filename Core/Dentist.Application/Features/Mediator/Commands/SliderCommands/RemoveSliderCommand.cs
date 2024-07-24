using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentist.Application.Features.Mediator.Commands.SliderCommands
{
    public class RemoveSliderCommand : IRequest
    {
        public int Id { get; set; }

        public RemoveSliderCommand(int id)
        {
            Id = id;
        }
    }
}
