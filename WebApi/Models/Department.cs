using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class Department
    {
        public int Id { get; set; }
        public int UniversityId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Place> Places { get; set; }

        public Department()
        {
            Places = new List<Place>();
        }
    }
}
