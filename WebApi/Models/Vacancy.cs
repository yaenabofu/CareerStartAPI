using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class Vacancy
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string EmploymentType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Requirements { get; set; }
        public string Responsibilities { get; set; }
        public string Conditions { get; set; }
        public string Salary { get; set; }
        public int Status { get; set; }
        public ICollection<Response> Responses { get; set; }

        public Vacancy()
        {
            Responses = new List<Response>();
        }
    }
}
