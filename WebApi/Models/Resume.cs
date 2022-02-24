using System.Collections.Generic;

namespace WebApi.Models
{
    public class Resume
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string PersonalInfo { get; set; }
        public string JobInfo { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        public string DateOfBirth { get; set; }
        public string Status { get; set; }
        public ICollection<Response> Responses { get; set; }
        public Resume()
        {
            Responses = new List<Response>();
        }
    }
}
