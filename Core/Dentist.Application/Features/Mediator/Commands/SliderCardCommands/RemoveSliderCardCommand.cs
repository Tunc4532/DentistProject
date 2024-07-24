using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentist.Application.Features.Mediator.Commands.SliderCardCommands
{
    public class RemoveSliderCardCommand : IRequest
    {
        public int Id { get; set; }

        public RemoveSliderCardCommand(int id)
        {
            Id = id;
        }
    }
}
