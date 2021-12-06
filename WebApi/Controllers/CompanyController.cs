using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.Repositories;
using WebApi.Repository;

namespace WebApi.Controllers
{
    public class CompanyController : Controller
    {
        private readonly IRepository<Company> companyRepo;
        public CompanyController(IRepository<Company> CompanyRepo)
        {
            companyRepo = CompanyRepo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var companies = companyRepo.Get();

            return Ok(companies);
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            var company = companyRepo.Get(id);

            if (company != null)
            {
                return Ok();
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult Create([FromBody] Company company)
        {
            companyRepo.Create(company);
            companyRepo.Save();

            return Ok();
        }

        [HttpPut]
        public IActionResult Update([FromBody] Company company)
        {
            companyRepo.Update(company);
            companyRepo.Save();

            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (companyRepo.Delete(id))
            {
                companyRepo.Save();

                return Ok();
            }

            return BadRequest();
        }
    }
}
