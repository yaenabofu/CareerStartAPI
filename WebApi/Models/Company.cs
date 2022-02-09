using System.Collections.Generic;

namespace WebApi.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public double Rating { get; set; }
        public int PlaceId { get; set; }
        public ICollection<PartnershipRequest> Partnerships { get; set; }
        public ICollection<Vacancy> Vacancies { get; set; }

        public Company()
        {
            Partnerships = new List<PartnershipRequest>();
            Vacancies = new List<Vacancy>();
        }
    }
}
