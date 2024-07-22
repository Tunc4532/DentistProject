using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentist.Application.Features.Mediator.Commands.CommentCommands
{
    public class CreateCommentCommand : IRequest
    {
        public string Image { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string NameSurname { get; set; }
    }
}
