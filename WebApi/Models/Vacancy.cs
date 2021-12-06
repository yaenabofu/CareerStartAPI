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
        public string Location { get; set; }
        public string TypeOfEmployment { get; set; }
        public string Name { get; set; }
        public string CompanyDescription { get; set; }
        public string Requirements { get; set; }
        public string Responsibilities { get; set; }
        public string Conditions { get; set; }
        public string Salary { get; set; }
    }
}
