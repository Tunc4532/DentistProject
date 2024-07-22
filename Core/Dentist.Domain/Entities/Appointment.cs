using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentist.Domain.Entities
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public string PatientTcKimlik { get; set; }
        public DateTime AppointmentDateTime { get; set; }
        public bool IsAvailable { get; set; }

        public int DoctorId { get; set; }
        public int? PatientId { get; set; }

        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }

        public List<ProcedureLog> ProcedureLogs { get; set; }
    }
}
