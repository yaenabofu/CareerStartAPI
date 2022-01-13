using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class ApplicationContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
        public ApplicationContext(DbContextOptions<ApplicationContext> dbContextOptions) : base(dbContextOptions)
        {
            Database.Migrate();
        }
        public DbSet<EP_Representative> EP_Representatives { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<StudentCompanyData> StudentCompanyDatas { get; set; }
        public DbSet<EventRequest> EventRequests { get; set; }
        public DbSet<PartnershipRequest> PartnershipRequests { get; set; }
        public DbSet<Response> Responses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<University> Universities { get; set; }
        public DbSet<Vacancy> Vacancies { get; set; }
        public DbSet<UNI_Representative> UNI_Representatives { get; set; }
        public DbSet<EducationalProgramme> EducationalProgrammes { get; set; }
    }
}
