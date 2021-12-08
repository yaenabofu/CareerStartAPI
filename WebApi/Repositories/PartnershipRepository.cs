using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.Repository;

namespace WebApi.Repositories
{
    public class PartnershipRepository : IRepository<Partnership>
    {
        private readonly ApplicationContext context;
        public PartnershipRepository(ApplicationContext Context)
        {
            context = Context;
        }
        public async Task<Partnership> Create(Partnership obj)
        {
            await context.Partnerships.AddAsync(obj);
            await context.SaveChangesAsync();

            return obj;
        }

        public async Task<bool> Delete(int id)
        {
            Partnership onDeletePartnership = await context.Partnerships.FindAsync(id);

            if (onDeletePartnership != null)
            {
                context.Partnerships.Remove(onDeletePartnership);
                await context.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<IEnumerable<Partnership>> Get()
        {
            return await context.Partnerships.ToListAsync();
        }

        public async Task<Partnership> Get(int id)
        {
            return await context.Partnerships.FindAsync(id);
        }

        public async Task<Partnership> Update(Partnership newEmployment)
        {
            context.Entry(newEmployment).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return newEmployment;
        }
    }
}
