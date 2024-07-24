using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentist.Domain.Entities
{
    public class WorkingHour
    {
        public int WorkingHourId { get; set; }
        public string Day { get; set; }
        public string Hour { get; set; }
        public string Phone { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
    }
}
