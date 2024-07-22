﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentist.Domain.Entities
{
    public class Education
    {
        public int EducationId { get; set; }
        public string University { get; set; }
        public string Year { get; set; }
        public string Description { get; set; }
        public Doctor Doctor { get; set; }
    }
}