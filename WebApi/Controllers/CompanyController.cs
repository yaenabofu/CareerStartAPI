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
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyController : Controller
    {
        private readonly IRepository<Company> companyRepo;
        public CompanyController(IRepository<Company> CompanyRepo)
        {
            companyRepo = CompanyRepo;
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get()
        {
            var companies = await companyRepo.Get();

            return Ok(companies);
        }
        [HttpGet("Get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var company = await companyRepo.Get(id);

            if (company != null)
            {
                return Ok(company);
            }

            return NotFound();
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] Company company)
        {
            await companyRepo.Create(company);

            return Ok(company);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] Company company)
        {
            await companyRepo.Update(company);

            return Ok(company);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await companyRepo.Delete(id))
            {
                return Ok(id);
            }

            return BadRequest();
        }
    }
}
