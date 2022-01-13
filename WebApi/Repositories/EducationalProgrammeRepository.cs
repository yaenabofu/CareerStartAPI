using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.Repository;

namespace WebApi.Repositories
{
    public class EducationalProgrammeRepository : IRepository<EducationalProgramme>
    {
        private readonly ApplicationContext context;

        public async Task<EducationalProgramme> Create(EducationalProgramme obj)
        {
            await context.EducationalProgrammes.AddAsync(obj);
            await context.SaveChangesAsync();

            return obj;
        }

        public async Task<bool> Delete(int id)
        {
            EducationalProgramme obj = await context.EducationalProgrammes.FindAsync(id);

            if (obj != null)
            {
                context.EducationalProgrammes.Remove(obj);
                await context.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<IEnumerable<EducationalProgramme>> Get()
        {
            return await context.EducationalProgrammes.ToListAsync();
        }

        public async Task<EducationalProgramme> Get(int id)
        {
            return await context.EducationalProgrammes.FindAsync(id);
        }

        public async Task<EducationalProgramme> Update(EducationalProgramme оbj)
        {
            context.Entry(оbj).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return оbj;
        }
    }
}