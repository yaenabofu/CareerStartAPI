using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class Student : User
    {
        public int EducationalProgrammeId { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Status { get; set; }
        public string ResumeURL { get; set; }
        public ICollection<Response> Responses { get; set; }

        public Student()
        {
            Responses = new List<Response>();
        }
    }
}
