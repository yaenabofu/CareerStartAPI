using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class University
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Rating { get; set; }
        public ICollection<AcademicSupervisor> AcademicSupervisors { get; set; }
        public ICollection<Student> Students { get; set; }
        public ICollection<Event> Events { get; set; }
        public ICollection<Partnership> Partnerships { get; set; }

        public University()
        {
            AcademicSupervisors = new List<AcademicSupervisor>();
            Students = new List<Student>();
            Events = new List<Event>();
            Partnerships = new List<Partnership>();
        }
    }
}
