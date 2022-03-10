using System.Collections.Generic;

namespace WebApi.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public ICollection<Vacancy> Vacancies { get; set; }
        public ICollection<Place> Places { get; set; }
        public ICollection<EventRequest> EventRequests { get; set; }
        public Company()
        {
            Vacancies = new List<Vacancy>();
            Places = new List<Place>();
            EventRequests = new List<EventRequest>();
        }
    }
}
