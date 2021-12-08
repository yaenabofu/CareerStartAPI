using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.Repository;

namespace WebApi.Repositories
{
    public class VacancyRepository : IRepository<Vacancy>
    {
        private readonly ApplicationContext context;
        public VacancyRepository(ApplicationContext Context)
        {
            context = Context;
        }
        public async Task<Vacancy> Create(Vacancy obj)
        {
            await context.Vacancies.AddAsync(obj);
            await context.SaveChangesAsync();

            return obj;
        }

        public async Task<bool> Delete(int id)
        {
            Vacancy vacancy = await context.Vacancies.FindAsync(id);

            if (vacancy != null)
            {
                context.Vacancies.Remove(vacancy);
                await context.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<IEnumerable<Vacancy>> Get()
        {
            return await context.Vacancies.ToListAsync();
        }

        public async Task<Vacancy> Get(int id)
        {
            return await context.Vacancies.FindAsync(id);
        }

        public async Task<Vacancy> Update(Vacancy newVacancy)
        {
            context.Entry(newVacancy).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return newVacancy;
        }
    }
}
