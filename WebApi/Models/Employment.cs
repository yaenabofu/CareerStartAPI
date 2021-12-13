using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class Employment
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int StudentId { get; set; }
        public string StudentReview { get; set; }
        public string CompanyReview { get; set; }
        public string EmploymentType { get; set; }
        public DateTime DateOfStart { get; set; }
        public DateTime DateOfEnd { get; set; }
    }
}
