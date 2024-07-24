using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentist.Application.Features.Mediator.Commands.SkillCommands
{
    public class UpdateSkillCommand : IRequest
    {
        public int SkillId { get; set; }
        public string Talent { get; set; }
        public int DoctorId { get; set; }
    }
}
