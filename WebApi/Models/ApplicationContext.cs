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
        public DbSet<AcademicSupervisor> AcademicSupervisors { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<CompanyStuff> CompanyStuff { get; set; }
        public DbSet<Employment> Employments { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventRequest> EventRequests { get; set; }
        public DbSet<Partnership> Partnerships { get; set; }
        public DbSet<Response> Responses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<University> Universities { get; set; }
        public DbSet<Vacancy> Vacancies { get; set; }
    }
}
