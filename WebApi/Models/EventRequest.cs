using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class EventRequest
    {
        public int Id { get; set; }
        public string EventType { get; set; }
        public string EventDescription { get; set; }
        public string WorkerDescription { get; set; }
        public DateTime EventDate { get; set; }
        public DateTime RequestSendDate { get; set; }
        public int PartnershipRequestId { get; set; }
        public int CompanyResponse { get; set; }
        public int EducationalProgrammeResponse { get; set; }
    }
}
