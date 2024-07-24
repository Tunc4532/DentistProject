using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentist.Application.Features.Mediator.Commands.EducationCommands
{
    public class UpdateEducationCommand : IRequest
    {
        public int EducationId { get; set; }
        public string University { get; set; }
        public string Year { get; set; }
        public string Description { get; set; }
        public int DoctorId { get; set; }
    }
}
