using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.Repository;

namespace WebApi.Repositories
{
    public class RoleRepository : IRepository<Role>
    {
        private readonly ApplicationContext context;
        public RoleRepository(ApplicationContext Context)
        {
            context = Context;
        }
        public async Task<Role> Create(Role obj)
        {
            await context.Roles.AddAsync(obj);
            await context.SaveChangesAsync();

            return obj;
        }

        public async Task<bool> Delete(int id)
        {
            Role obj = await context.Roles.FindAsync(id);

            if (obj != null)
            {
                context.Roles.Remove(obj);
                await context.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<IEnumerable<Role>> Get()
        {
            return await context.Roles.ToListAsync();
        }

        public async Task<Role> Get(int id)
        {
            return await context.Roles.FindAsync(id);
        }

        public async Task<Role> Update(Role obj)
        {
            context.Entry(obj).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return obj;
        }
    }
}
