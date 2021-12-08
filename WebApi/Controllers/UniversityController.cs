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
    public class UniversityController : Controller
    {
        private readonly IRepository<University> universityRepo;
        public UniversityController(IRepository<University> UniversityRepo)
        {
            this.universityRepo = UniversityRepo;
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get()
        {
            var universities = await universityRepo.Get();

            return Ok(universities);
        }
        [HttpGet("Get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var university = await universityRepo.Get(id);

            if (university != null)
            {
                return Ok(university);
            }

            return NotFound();
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] University university)
        {
            await universityRepo.Create(university);

            return Ok(university);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] University university)
        {
            await universityRepo.Update(university);

            return Ok(university);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await universityRepo.Delete(id))
            {
                return Ok(id);
            }

            return BadRequest();
        }
    }
}
