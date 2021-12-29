using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.Repository;

namespace WebApi.Repositories
{
    public class EventRequestRepository : IRepository<EventRequest>
    {
        private readonly ApplicationContext context;
        public EventRequestRepository(ApplicationContext Context)
        {

            context = Context;
        }
        public async Task<EventRequest> Create(EventRequest obj)
        {
            await context.EventRequests.AddAsync(obj);
            await context.SaveChangesAsync();

            return obj;
        }

        public async Task<bool> Delete(int id)
        {
            EventRequest onDeleteEventRequest = await context.EventRequests.FindAsync(id);

            if (onDeleteEventRequest != null)
            {
                context.EventRequests.Remove(onDeleteEventRequest);
                await context.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<IEnumerable<EventRequest>> Get()
        {
            return await context.EventRequests.ToListAsync();
        }

        public async Task<EventRequest> Get(int id)
        {
            return await context.EventRequests.FindAsync(id);
        }

        public async Task<EventRequest> Update(EventRequest newEventRequest)
        {
            context.Entry(newEventRequest).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return newEventRequest;
        }
    }
}
