using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentist.Application.Features.Mediator.Commands.CategoryCardCommands
{
    public class RemoveCategoryCardCommand :  IRequest
    {
        public int Id { get; set; }

        public RemoveCategoryCardCommand(int id)
        {
            Id = id;
        }
    }
}
