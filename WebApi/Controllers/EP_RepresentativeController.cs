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
    public class EP_RepresentativeController : Controller
    {
        private readonly IRepository<EP_Representative> academicSupervisorRepo;
        public EP_RepresentativeController(IRepository<EP_Representative> AcademicSupervisorRepo)
        {
            this.academicSupervisorRepo = AcademicSupervisorRepo;
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get()
        {
            var academicSupervisors = await academicSupervisorRepo.Get();

            return Ok(academicSupervisors);
        }
        [HttpGet("Get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var academicSupervisor = await academicSupervisorRepo.Get(id);

            if (academicSupervisor != null)
            {
                return Ok(academicSupervisor);
            }

            return NotFound();
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] EP_Representative academicSupervisor)
        {
            await academicSupervisorRepo.Create(academicSupervisor);

            return Ok(academicSupervisor);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] EP_Representative academicSupervisor)
        {
            await academicSupervisorRepo.Update(academicSupervisor);

            return Ok(academicSupervisor);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await academicSupervisorRepo.Delete(id))
            {
                return Ok(id);
            }

            return BadRequest();
        }
    }
}
