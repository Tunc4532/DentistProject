using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentist.Application.Features.Mediator.Results.SkillResults
{
    public class GetSkillByIdQueryResult
    {
        public int SkillId { get; set; }
        public string Talent { get; set; }
        public int DoctorId { get; set; }
    }
}
