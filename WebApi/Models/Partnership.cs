using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class Partnership
    {
        public int Id { get; set; }
        public int UniversityId { get; set; }
        public int CompanyId { get; set; }
    }
}
