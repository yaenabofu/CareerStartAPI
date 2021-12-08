using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.Repository;

namespace WebApi.Repositories
{
    public class EventRepository : IRepository<Event>
    {
        private readonly ApplicationContext context;
        public EventRepository(ApplicationContext Context)
        {
            context = Context;
        }
        public async Task<Event> Create(Event obj)
        {
            await context.Events.AddAsync(obj);
            await context.SaveChangesAsync();

            return obj;
        }

        public async Task<bool> Delete(int id)
        {
            Event onDeleteEvent = await context.Events.FindAsync(id);

            if (onDeleteEvent != null)
            {
                context.Events.Remove(onDeleteEvent);
                await context.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<IEnumerable<Event>> Get()
        {
            return await context.Events.ToListAsync();
        }

        public async Task<Event> Get(int id)
        {
            return await context.Events.FindAsync(id);
        }

        public async Task<Event> Update(Event newEmployment)
        {
            context.Entry(newEmployment).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return newEmployment;
        }
    }
}
