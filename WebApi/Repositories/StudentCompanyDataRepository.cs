using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.Repository;

namespace WebApi.Repositories
{
    public class StudentCompanyDataRepository : IRepository<StudentCompanyData>
    {
        private readonly ApplicationContext context;
        public StudentCompanyDataRepository(ApplicationContext Context)
        {
            context = Context;
        }
        public async Task<StudentCompanyData> Create(StudentCompanyData obj)
        {
            await context.StudentCompanyDatas.AddAsync(obj);
            await context.SaveChangesAsync();

            return obj;
        }

        public async Task<bool> Delete(int id)
        {
            StudentCompanyData obj = await context.StudentCompanyDatas.FindAsync(id);

            if (obj != null)
            {
                context.StudentCompanyDatas.Remove(obj);
                await context.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<IEnumerable<StudentCompanyData>> Get()
        {
            return await context.StudentCompanyDatas.ToListAsync();
        }

        public async Task<StudentCompanyData> Get(int id)
        {
            return await context.StudentCompanyDatas.FindAsync(id);
        }

        public async Task<StudentCompanyData> Update(StudentCompanyData obj)
        {
            context.Entry(obj).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return obj;
        }
    }
}
