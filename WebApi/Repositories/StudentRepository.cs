using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.Repository;

namespace WebApi.Repositories
{
    public class StudentRepository : IRepository<Student>
    {
        private readonly ApplicationContext context;
        public StudentRepository(ApplicationContext Context)
        {
            context = Context;
        }
        public async Task<Student> Create(Student obj)
        {
            await context.Students.AddAsync(obj);
            await context.SaveChangesAsync();

            return obj;
        }

        public async Task<bool> Delete(int id)
        {
            Student onDeleteStudent = await context.Students.FindAsync(id);

            if (onDeleteStudent != null)
            {
                context.Students.Remove(onDeleteStudent);
                await context.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<IEnumerable<Student>> Get()
        {
            return await context.Students.ToListAsync();
        }

        public async Task<Student> Get(int id)
        {
            return await context.Students.FindAsync(id);
        }

        public async Task<Student> Update(Student student)
        {
            context.Entry(student).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return student;
        }
    }
}
