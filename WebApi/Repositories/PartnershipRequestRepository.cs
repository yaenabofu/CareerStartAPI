using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.Repository;

namespace WebApi.Repositories
{
    public class PartnershipRequestRepository : IRepository<PartnershipRequest>
    {
        private readonly ApplicationContext context;
        public PartnershipRequestRepository(ApplicationContext Context)
        {
            context = Context;
        }
        public async Task<PartnershipRequest> Create(PartnershipRequest obj)
        {
            await context.PartnershipRequests.AddAsync(obj);
            await context.SaveChangesAsync();

            return obj;
        }

        public async Task<bool> Delete(int id)
        {
            PartnershipRequest obj = await context.PartnershipRequests.FindAsync(id);

            if (obj != null)
            {
                context.PartnershipRequests.Remove(obj);
                await context.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<IEnumerable<PartnershipRequest>> Get()
        {
            return await context.PartnershipRequests.ToListAsync();
        }

        public async Task<PartnershipRequest> Get(int id)
        {
            return await context.PartnershipRequests.FindAsync(id);
        }

        public async Task<PartnershipRequest> Update(PartnershipRequest obj)
        {
            context.Entry(obj).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return obj;
        }
    }
}
