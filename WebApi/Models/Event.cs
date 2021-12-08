using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class Event : baseEvent
    {
        public string EventReview { get; set; }
        public ICollection<University> Universities { get; set; }
        public ICollection<Company> Companies { get; set; }

        public Event()
        {
            Universities = new List<University>();
            Companies = new List<Company>();
        }
    }
}
