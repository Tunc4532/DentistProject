using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentist.Application.Features.Mediator.Results.AuthorizationResults
{
    public class LoginQueryResult
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }
        public bool IsExist { get; set; }
        //public int? DoctorId { get; set; }
        //public int? PatientId { get; set; }
    }
}
