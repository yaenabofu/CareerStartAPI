using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.Repository;

namespace WebApi.Repositories
{
    public class CompanyRepository : IRepository<Company>
    {
        private readonly ApplicationContext context;
        public CompanyRepository(ApplicationContext Context)
        {
            context = Context;
        }
        public void Create(Company obj)
        {
            context.Companies.Add(obj);
        }

        public bool Delete(int id)
        {
            Company company = context.Companies.SingleOrDefault(x => x.Id == id);

            if (company != null)
            {
                context.Companies.Remove(company);
                return true;
            }

            return false;
        }

        public IEnumerable<Company> Get()
        {
            return context.Companies.ToList();
        }

        public Company Get(int id)
        {
            return context.Companies.Find(id);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(Company newCompany)
        {
            context.Companies.Update(newCompany);
        }
    }
}
