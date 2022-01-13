using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class University
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Rating { get; set; }
        public ICollection<UNI_Representative> UNI_Representatives { get; set; }
        public ICollection<EducationalProgramme> EducationalProgrammes { get; set; }

        public University()
        {
            EducationalProgrammes = new List<EducationalProgramme>();
            UNI_Representatives = new List<UNI_Representative>();
        }
    }
}
