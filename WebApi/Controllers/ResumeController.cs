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
    public class ResumeController : Controller
    {
        private readonly IRepository<Resume> resumeRepo;
        public ResumeController(IRepository<Resume> ResumeRepo)
        {
            this.resumeRepo = ResumeRepo;
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get()
        {
            var data = await resumeRepo.Get();

            return Ok(data);
        }
        [HttpGet("Get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await resumeRepo.Get(id);

            if (data != null)
            {
                return Ok(data);
            }

            return NotFound();
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] Resume data)
        {
            await resumeRepo.Create(data);

            return Ok(data);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] Resume data)
        {
            await resumeRepo.Update(data);

            return Ok(data);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await resumeRepo.Delete(id))
            {
                return Ok(id);
            }

            return BadRequest();
        }
    }
}
