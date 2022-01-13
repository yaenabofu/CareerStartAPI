using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.Repository;

namespace WebApi.Repositories
{
    public class UniversityRepository : IRepository<University>
    {
        private readonly ApplicationContext context;
        public UniversityRepository(ApplicationContext Context)
        {
            context = Context;
        }
        public async Task<University> Create(University obj)
        {
            await context.Universities.AddAsync(obj);
            await context.SaveChangesAsync();

            return obj;
        }

        public async Task<bool> Delete(int id)
        {
            University obj = await context.Universities.FindAsync(id);

            if (obj != null)
            {
                context.Universities.Remove(obj);
                await context.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<IEnumerable<University>> Get()
        {
            return await context.Universities.ToListAsync();
        }

        public async Task<University> Get(int id)
        {
            return await context.Universities.FindAsync(id);
        }

        public async Task<University> Update(University obj)
        {
            context.Entry(obj).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return obj;
        }
    }
}
