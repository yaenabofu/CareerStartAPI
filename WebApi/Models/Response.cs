using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class Response
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int VacancyId { get; set; }
        public bool RespondedSide { get; set; }
        public bool toInterview { get; set; }
    }
}
