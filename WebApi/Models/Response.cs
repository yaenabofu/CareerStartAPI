using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class Response
    {
        public int Id { get; set; }
        public int ResumeId { get; set; }
        public int VacancyId { get; set; }
        public int Initiator { get; set; }
        public DateTime Date { get; set; }
        public ICollection<PerformanceReview> PerformanceReviews { get; set; }

        public Response()
        {
            PerformanceReviews = new List<PerformanceReview>();
        }
    }
}
