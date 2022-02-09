using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.Repository;

namespace WebApi.Repositories
{
    public class ResumeRepository : IRepository<Resume>
    {
        private readonly ApplicationContext context;
        public ResumeRepository(ApplicationContext Context)
        {
            context = Context;
        }
        public async Task<Resume> Create(Resume obj)
        {
            await context.Resumes.AddAsync(obj);
            await context.SaveChangesAsync();

            return obj;
        }

        public async Task<bool> Delete(int id)
        {
            Resume obj = await context.Resumes.FindAsync(id);

            if (obj != null)
            {
                context.Resumes.Remove(obj);
                await context.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<IEnumerable<Resume>> Get()
        {
            return await context.Resumes.ToListAsync();
        }

        public async Task<Resume> Get(int id)
        {
            return await context.Resumes.FindAsync(id);
        }

        public async Task<Resume> Update(Resume obj)
        {
            context.Entry(obj).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return obj;
        }
    }
}
