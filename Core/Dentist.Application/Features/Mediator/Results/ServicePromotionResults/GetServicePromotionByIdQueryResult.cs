using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentist.Application.Features.Mediator.Results.ServicePromotionResults
{
    public class GetServicePromotionByIdQueryResult
    {
        public int ServicePromotionId { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
