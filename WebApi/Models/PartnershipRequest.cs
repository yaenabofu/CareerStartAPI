using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class PartnershipRequest
    {
        public int Id { get; set; }
        public int AcademicDisciplineId { get; set; }
        public int CompanyId { get; set; }
        public int CompanyResponse { get; set; }
        public int EducationalProgrammeResponse { get; set; }
    }
}
