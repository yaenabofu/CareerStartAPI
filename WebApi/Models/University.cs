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
        public double Rating { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public ICollection<Department> Departments { get; set; }
        public ICollection<EventRequest> EventRequests { get; set; }

        public University()
        {
            EventRequests = new List<EventRequest>();
            Departments = new List<Department>();
        }
    }
}
