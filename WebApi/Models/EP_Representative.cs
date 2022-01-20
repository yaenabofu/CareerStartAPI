using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class EP_Representative : User
    {
        public int EducationalProgrammeId { get; set; }
    }
}
