﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class AcademicSupervisor : BaseUser
    {
        public int UniversityId { get; set; }
    }
}
