using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class EventRequest : baseEvent
    {
        public DateTime RequestSendDate { get; set; }
        public bool Happening { get; set; }
        public ICollection<AcademicSupervisor> AcademicSupervisors { get; set; }
        public ICollection<CompanyStuff> CompanyStuffs { get; set; }

        public EventRequest()
        {
            AcademicSupervisors = new List<AcademicSupervisor>();
            CompanyStuffs = new List<CompanyStuff>();
        }
    }
}
