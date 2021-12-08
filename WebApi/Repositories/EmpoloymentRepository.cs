using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.Repository;

namespace WebApi.Repositories
{
    public class EmpoloymentRepository : IRepository<Employment>
    {
        private readonly ApplicationContext context;
        public EmpoloymentRepository(ApplicationContext Context)
        {
            context = Context;
        }
        public async Task<Employment> Create(Employment obj)
        {
            await context.Employments.AddAsync(obj);
            await context.SaveChangesAsync();

            return obj;
        }

        public async Task<bool> Delete(int id)
        {
            Employment employment = await context.Employments.FindAsync(id);

            if (employment != null)
            {
                context.Employments.Remove(employment);
                await context.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<IEnumerable<Employment>> Get()
        {
            return await context.Employments.ToListAsync();
        }

        public async Task<Employment> Get(int id)
        {
            return await context.Employments.FindAsync(id);
        }

        public async Task<Employment> Update(Employment newEmployment)
        {
            context.Entry(newEmployment).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return newEmployment;
        }
    }
}
