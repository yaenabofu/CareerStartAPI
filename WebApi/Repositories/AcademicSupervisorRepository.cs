using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.Repository;

namespace WebApi.Repositories
{
    public class AcademicSupervisorRepository : IRepository<AcademicSupervisor>
    {
        private readonly ApplicationContext context;
        public AcademicSupervisorRepository(ApplicationContext Context)
        {
            context = Context;
        }
        public async Task<AcademicSupervisor> Create(AcademicSupervisor obj)
        {
            await context.AcademicSupervisors.AddAsync(obj);
            await context.SaveChangesAsync();

            return obj;
        }

        public async Task<bool> Delete(int id)
        {
            AcademicSupervisor academicSupervisor = await context.AcademicSupervisors.FindAsync(id);

            if (academicSupervisor != null)
            {
                context.AcademicSupervisors.Remove(academicSupervisor);
                await context.SaveChangesAsync();

                return true;
            }





            return false;
        }

        public async Task<IEnumerable<AcademicSupervisor>> Get()
        {
            return await context.AcademicSupervisors.ToListAsync();
        }

        public async Task<AcademicSupervisor> Get(int id)
        {
            return await context.AcademicSupervisors.FindAsync(id);
        }

        public async Task<AcademicSupervisor> Update(AcademicSupervisor academicSupervisor)
        {
            context.Entry(academicSupervisor).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return academicSupervisor;
        }
    }
}
