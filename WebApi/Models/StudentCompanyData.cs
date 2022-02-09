using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class StudentCompanyData
    {
        public int Id { get; set; }
        public string StudentReview { get; set; }
        public string CompanyReview { get; set; }
        public string EmploymentType { get; set; }
        public int ResponseId { get; set; }
    }
}
