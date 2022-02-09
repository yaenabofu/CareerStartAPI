using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.Repository;

namespace WebApi.Repositories
{
    public class UserEducationalProgrammeDataRepository : IRepository<UserEducationalProgrammeData>
    {
        private readonly ApplicationContext context;
        public UserEducationalProgrammeDataRepository(ApplicationContext Context)
        {
            context = Context;
        }
        public async Task<UserEducationalProgrammeData> Create(UserEducationalProgrammeData obj)
        {
            await context.UserEducationalProgrammeDatas.AddAsync(obj);
            await context.SaveChangesAsync();

            return obj;
        }

        public async Task<bool> Delete(int id)
        {
            UserEducationalProgrammeData obj = await context.UserEducationalProgrammeDatas.FindAsync(id);

            if (obj != null)
            {
                context.UserEducationalProgrammeDatas.Remove(obj);
                await context.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<IEnumerable<UserEducationalProgrammeData>> Get()
        {
            return await context.UserEducationalProgrammeDatas.ToListAsync();
        }

        public async Task<UserEducationalProgrammeData> Get(int id)
        {
            return await context.UserEducationalProgrammeDatas.FindAsync(id);
        }

        public async Task<UserEducationalProgrammeData> Update(UserEducationalProgrammeData obj)
        {
            context.Entry(obj).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return obj;
        }
    }
}
