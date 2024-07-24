using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentist.Application.Features.Mediator.Results.EducationResults
{
    public class GetEducationByIdQueryResult
    {
        public int EducationId { get; set; }
        public string University { get; set; }
        public string Year { get; set; }
        public string Description { get; set; }
        public int DoctorId { get; set; }
    }
}
