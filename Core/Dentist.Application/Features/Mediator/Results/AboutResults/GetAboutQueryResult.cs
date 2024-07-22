using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentist.Application.Features.Mediator.Results.AboutResults
{
    public class GetAboutQueryResult
    {
        public int AboutId { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
