using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.Repository;

namespace WebApi.Repositories
{
    public class PlaceRepository : IRepository<Place>
    {
        private readonly ApplicationContext context;
        public PlaceRepository(ApplicationContext Context)
        {
            context = Context;
        }
        public async Task<Place> Create(Place obj)
        {
            await context.Places.AddAsync(obj);
            await context.SaveChangesAsync();

            return obj;
        }

        public async Task<bool> Delete(int id)
        {
            Place obj = await context.Places.FindAsync(id);

            if (obj != null)
            {
                context.Places.Remove(obj);
                await context.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<IEnumerable<Place>> Get()
        {
            return await context.Places.ToListAsync();
        }

        public async Task<Place> Get(int id)
        {
            return await context.Places.FindAsync(id);
        }

        public async Task<Place> Update(Place obj)
        {
            context.Entry(obj).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return obj;
        }
    }
}
