using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentist.Domain.Entities
{
    public class SocialMedia
    {
        public int SocialMediaId { get; set; }
        public string Icon { get; set; }
        public string Url { get; set; }
        public Doctor Doctor { get; set; }
    }
}
