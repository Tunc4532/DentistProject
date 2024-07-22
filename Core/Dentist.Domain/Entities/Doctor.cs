using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentist.Domain.Entities
{
    public class Doctor
    {
        public int DoctorId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Image { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public bool IsApproved { get; set; }

        public int? UserId { get; set; }
        public User? User { get; set; }

        public List<Appointment> Appointments { get; set; }
        public List<SocialMedia> SocialMedias { get; set; }
        public List<Education> Educations { get; set; }
        public List<Skill> Skills { get; set; }
        public List<WorkingHour> WorkingHours { get; set; }
    }
}
