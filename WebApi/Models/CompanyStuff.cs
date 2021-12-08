using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class CompanyStuff : baseUser
    {
        public int CompanyId { get; set; }
        public ICollection<EventRequest> EventRequests { get; set; }
        public ICollection<Vacancy> Vacancies { get; set; }

        public CompanyStuff()
        {
            EventRequests = new List<EventRequest>();
            Vacancies = new List<Vacancy>();
        }
    }
}
