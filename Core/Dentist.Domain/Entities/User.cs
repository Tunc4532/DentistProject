using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentist.Domain.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string PasswordSalt { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime CreatedDate { get; set; }

        public int UserRoleId { get; set; }
        public UserRole Role { get; set; }

        public List<Doctor> Doctors { get; set; }
        public List<Patient> Patients { get; set; }

    }
}
