using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.Repository;

namespace WebApi.Repositories
{
    public class EP_RepresentativeRepository : IRepository<EP_Representative>
    {
        private readonly ApplicationContext context;
        public EP_RepresentativeRepository(ApplicationContext Context)
        {
            context = Context;
        }
        public async Task<EP_Representative> Create(EP_Representative obj)
        {
            await context.EP_Representatives.AddAsync(obj);
            await context.SaveChangesAsync();

            return obj;
        }

        public async Task<bool> Delete(int id)
        {
            EP_Representative obj = await context.EP_Representatives.FindAsync(id);

            if (obj != null)
            {
                context.EP_Representatives.Remove(obj);
                await context.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<IEnumerable<EP_Representative>> Get()
        {
            return await context.EP_Representatives.ToListAsync();
        }

        public async Task<EP_Representative> Get(int id)
        {
            return await context.EP_Representatives.FindAsync(id);
        }

        public async Task<EP_Representative> Update(EP_Representative obj)
        {
            context.Entry(obj).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return obj;
        }
    }
}
