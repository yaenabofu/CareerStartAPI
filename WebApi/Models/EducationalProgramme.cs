using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class EducationalProgramme
    {
        public int Id { get; set; }
        public int UniversityId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<EP_Representative> EP_Representatives { get; set; }
        public ICollection<Student> Students { get; set; }
        public ICollection<PartnershipRequest> Partnerships { get; set; }

        public EducationalProgramme()
        {
            EP_Representatives = new List<EP_Representative>();
            Students = new List<Student>();
            Partnerships = new List<PartnershipRequest>();
        }
    }
}
