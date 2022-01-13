using System.Collections.Generic;

namespace WebApi.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public ICollection<Employee> Employees { get; set; }
        public ICollection<PartnershipRequest> Partnerships { get; set; }
        public ICollection<Vacancy> Vacancies { get; set; }

        public Company()
        {
            Employees = new List<Employee>();
            Partnerships = new List<PartnershipRequest>();
            Vacancies = new List<Vacancy>();
        }
    }
}
