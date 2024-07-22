using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentist.Application.Features.Mediator.Commands.CoverLetterCommands
{
    public class RemoveCoverLetterCommand : IRequest
    {
        public int Id { get; set; }

        public RemoveCoverLetterCommand(int id)
        {
            Id = id;
        }
    }
}
