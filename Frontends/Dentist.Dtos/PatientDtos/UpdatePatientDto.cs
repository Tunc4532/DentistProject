using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentist.Dtos.PatientDtos
{
    public class UpdatePatientDto
    {
        public int PatientId { get; set; }
        public string TcKimlik { get; set; }
        public string NameSurname { get; set; }
        public string Phone { get; set; }
        public DateTime Age { get; set; }

        public int? UserId { get; set; }
    }
}
