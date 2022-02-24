using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.Repository;

namespace WebApi.Repositories
{
    public class DepartmentRepository : IRepository<Department>
    {
        private readonly ApplicationContext context;
        public DepartmentRepository(ApplicationContext Context)
        {
            context = Context;
        }
        public async Task<Department> Create(Department obj)
        {
            await context.Departments.AddAsync(obj);
            await context.SaveChangesAsync();

            return obj;
        }

        public async Task<bool> Delete(int id)
        {
            Department obj = await context.Departments.FindAsync(id);

            if (obj != null)
            {
                context.Departments.Remove(obj);
                await context.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<IEnumerable<Department>> Get()
        {
            return await context.Departments.ToListAsync();
        }

        public async Task<Department> Get(int id)
        {
            return await context.Departments.FindAsync(id);
        }

        public async Task<Department> Update(Department оbj)
        {
            context.Entry(оbj).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return оbj;
        }
    }
}