using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.Repository;


namespace WebApi.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private readonly ApplicationContext context;
        public UserRepository(ApplicationContext Context)
        {
            context = Context;
        }
        public async Task<User> Create(User obj)
        {
            await context.Users.AddAsync(obj);
            await context.SaveChangesAsync();

            return obj;
        }

        public async Task<bool> Delete(int id)
        {
            User obj = await context.Users.FindAsync(id);

            if (obj != null)
            {
                context.Users.Remove(obj);
                await context.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<IEnumerable<User>> Get()
        {
            return await context.Users.ToListAsync();
        }

        public async Task<User> Get(int id)
        {
            return await context.Users.FindAsync(id);
        }

        public async Task<User> Update(User obj)
        {
            context.Entry(obj).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return obj;
        }
    }
}
