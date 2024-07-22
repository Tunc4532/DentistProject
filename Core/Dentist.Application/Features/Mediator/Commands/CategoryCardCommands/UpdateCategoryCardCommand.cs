using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentist.Application.Features.Mediator.Commands.CategoryCardCommands
{
    public class UpdateCategoryCardCommand : IRequest
    {
        public int CategoryCardId { get; set; }
        public string Icon { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
