using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentist.Domain.Entities
{
    public class Skill
    {
        public int SkillId { get; set; }
        public string Talent { get; set; }
        public Doctor Doctor { get; set; }
    }
}
