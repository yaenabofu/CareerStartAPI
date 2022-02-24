using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.Repository;

namespace WebApi.Repositories
{
    public class PerformanceReviewRepository : IRepository<PerformanceReview>
    {
        private readonly ApplicationContext context;
        public PerformanceReviewRepository(ApplicationContext Context)
        {
            context = Context;
        }
        public async Task<PerformanceReview> Create(PerformanceReview obj)
        {
            await context.PerformanceReviews.AddAsync(obj);
            await context.SaveChangesAsync();

            return obj;
        }

        public async Task<bool> Delete(int id)
        {
            PerformanceReview obj = await context.PerformanceReviews.FindAsync(id);

            if (obj != null)
            {
                context.PerformanceReviews.Remove(obj);
                await context.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<IEnumerable<PerformanceReview>> Get()
        {
            return await context.PerformanceReviews.ToListAsync();
        }

        public async Task<PerformanceReview> Get(int id)
        {
            return await context.PerformanceReviews.FindAsync(id);
        }

        public async Task<PerformanceReview> Update(PerformanceReview obj)
        {
            context.Entry(obj).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return obj;
        }
    }
}
