using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public ICollection<CompanyStuff> CompanyStuffs { get; set; }
        public ICollection<Partnership> Partnerships { get; set; }
        public ICollection<Vacancy> Vacancies { get; set; }

        public Company()
        {
            CompanyStuffs = new List<CompanyStuff>();
            Partnerships = new List<Partnership>();
            Vacancies = new List<Vacancy>();
        }
    }
}
