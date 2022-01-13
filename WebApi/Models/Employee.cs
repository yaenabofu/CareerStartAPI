using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class Employee : BaseUser
    {
        public int CompanyId { get; set; }
    }
}
