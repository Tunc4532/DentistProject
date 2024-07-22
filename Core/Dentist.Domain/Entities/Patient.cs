using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentist.Domain.Entities
{
    public class Patient
    {
        public int PatientId { get; set; }
        public string TcKimlik { get; set; }
        public string NameSurname { get; set; }
        public string Phone { get; set; }
        public DateTime Age { get; set; }

        public int? UserId { get; set; }
        public User? User { get; set; }

        public List<Appointment> Appointments { get; set; }
    }
}
