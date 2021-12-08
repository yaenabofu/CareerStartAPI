using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.Repository;

namespace WebApi.Repositories
{
    public class CompanyStuffRepository : IRepository<CompanyStuff>
    {
        private readonly ApplicationContext context;
        public CompanyStuffRepository(ApplicationContext Context)
        {
            context = Context;
        }
        public async Task<CompanyStuff> Create(CompanyStuff obj)
        {
            await context.CompanyStuff.AddAsync(obj);
            await context.SaveChangesAsync();

            return obj;
        }

        public async Task<bool> Delete(int id)
        {
            CompanyStuff companyStuff = await context.CompanyStuff.FindAsync(id);

            if (companyStuff != null)
            {
                context.CompanyStuff.Remove(companyStuff);
                await context.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<IEnumerable<CompanyStuff>> Get()
        {
            return await context.CompanyStuff.ToListAsync();
        }

        public async Task<CompanyStuff> Get(int id)
        {
            return await context.CompanyStuff.FindAsync(id);
        }

        public async Task<CompanyStuff> Update(CompanyStuff companyStuff)
        {
            context.Entry(companyStuff).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return companyStuff;
        }
    }
}
