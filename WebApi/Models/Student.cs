using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class Student : baseUser
    {
        public int UniversityId { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Faculty { get; set; }
        public string Speciality { get; set; }
        public string Status { get; set; }
        public string PortfolioURL { get; set; }
        public string ResumeURL { get; set; }
        public ICollection<Response> Responses { get; set; }
        public ICollection<Employment> Employments { get; set; }

        public Student()
        {
            Responses = new List<Response>();
            Employments = new List<Employment>();
        }
    }
}
