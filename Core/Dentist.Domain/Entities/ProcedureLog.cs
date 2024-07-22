using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentist.Domain.Entities
{
    public class ProcedureLog
    {
        public int ProcedureLogId { get; set; }
        public int AppointmentId { get; set; } 
        public string ProcedureName { get; set; }
        public string Description { get; set; }
        public string PerformedBy { get; set; }
        public DateTime PerformedAt { get; set; }

        public Appointment Appointment { get; set; }
    }
}
