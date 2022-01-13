using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.Repository;

namespace WebApi.Repositories
{
    public class UNI_RepresentativeRepository : IRepository<UNI_Representative>
    {
        private readonly ApplicationContext context;
        public UNI_RepresentativeRepository(ApplicationContext Context)
        {
            context = Context;
        }
        public async Task<UNI_Representative> Create(UNI_Representative obj)
        {
            await context.UNI_Representatives.AddAsync(obj);
            await context.SaveChangesAsync();

            return obj;
        }

        public async Task<bool> Delete(int id)
        {
            UNI_Representative obj = await context.UNI_Representatives.FindAsync(id);

            if (obj != null)
            {
                context.UNI_Representatives.Remove(obj);
                await context.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<IEnumerable<UNI_Representative>> Get()
        {
            return await context.UNI_Representatives.ToListAsync();
        }

        public async Task<UNI_Representative> Get(int id)
        {
            return await context.UNI_Representatives.FindAsync(id);
        }

        public async Task<UNI_Representative> Update(UNI_Representative obj)
        {
            context.Entry(obj).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return obj;
        }
    }
}
