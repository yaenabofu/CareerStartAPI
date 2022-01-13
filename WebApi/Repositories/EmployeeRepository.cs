using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.Repository;

namespace WebApi.Repositories
{
    public class EmployeeRepository : IRepository<Employee>
    {
        private readonly ApplicationContext context;
        public EmployeeRepository(ApplicationContext Context)
        {
            context = Context;
        }
        public async Task<Employee> Create(Employee obj)
        {
            await context.Employees.AddAsync(obj);
            await context.SaveChangesAsync();

            return obj;
        }

        public async Task<bool> Delete(int id)
        {
            Employee obj = await context.Employees.FindAsync(id);

            if (obj != null)
            {
                context.Employees.Remove(obj);
                await context.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<IEnumerable<Employee>> Get()
        {
            return await context.Employees.ToListAsync();
        }

        public async Task<Employee> Get(int id)
        {
            return await context.Employees.FindAsync(id);
        }

        public async Task<Employee> Update(Employee obj)
        {
            context.Entry(obj).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return obj;
        }
    }
}
