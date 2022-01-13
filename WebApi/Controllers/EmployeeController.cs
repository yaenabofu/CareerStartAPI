using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.Repository;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        private readonly IRepository<Employee> companyStuffRepo;
        public EmployeeController(IRepository<Employee> CompanyStuffRepo)
        {
            this.companyStuffRepo = CompanyStuffRepo;
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get()
        {
            var companyStuff = await companyStuffRepo.Get();

            return Ok(companyStuff);
        }
        [HttpGet("Get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var companyStuff = await companyStuffRepo.Get(id);

            if (companyStuff != null)
            {
                return Ok(companyStuff);
            }

            return NotFound();
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] Employee companyStuff)
        {
            await companyStuffRepo.Create(companyStuff);

            return Ok(companyStuff);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] Employee companyStuff)
        {
            await companyStuffRepo.Update(companyStuff);

            return Ok(companyStuff);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await companyStuffRepo.Delete(id))
            {
                return Ok(id);
            }

            return BadRequest();
        }
    }
}
