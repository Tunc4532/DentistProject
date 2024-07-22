using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentist.Domain.Entities
{
    public class CategoryCard
    {
        public int CategoryCardId { get; set; }
        public string Icon { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
