using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentist.Application.Features.Mediator.Results.WorkingHourResults
{
    public class GetWorkingHourQueryResult
    {
        public int WorkingHourId { get; set; }
        public string Day { get; set; }
        public string Hour { get; set; }
        public string Phone { get; set; }
        public int DoctorId { get; set; }
    }
}
