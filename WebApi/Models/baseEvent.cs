using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public abstract class baseEvent
    {
        public int Id { get; set; }
        public string EventType { get; set; }
        public string EventDescription { get; set; }
        public string WorkerDescription { get; set; }
        public DateTime EventDate { get; set; }
    }
}
