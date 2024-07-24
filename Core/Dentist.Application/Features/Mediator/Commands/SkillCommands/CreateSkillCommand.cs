using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentist.Application.Features.Mediator.Commands.SkillCommands
{
    public class CreateSkillCommand : IRequest
    {
        public string Talent { get; set; }
        public int DoctorId { get; set; }
    }
}
