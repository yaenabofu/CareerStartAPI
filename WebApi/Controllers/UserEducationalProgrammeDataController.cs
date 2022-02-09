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
    public class UserEducationalProgrammeDataController : Controller
    {
        private readonly IRepository<UserEducationalProgrammeData> userEducationalProgrammeDataRepo;
        public UserEducationalProgrammeDataController(IRepository<UserEducationalProgrammeData> UserEducationalProgrammeDataRepo)
        {
            this.userEducationalProgrammeDataRepo = UserEducationalProgrammeDataRepo;
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get()
        {
            var data = await userEducationalProgrammeDataRepo.Get();

            return Ok(data);
        }
        [HttpGet("Get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await userEducationalProgrammeDataRepo.Get(id);

            if (data != null)
            {
                return Ok(data);
            }

            return NotFound();
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] UserEducationalProgrammeData data)
        {
            await userEducationalProgrammeDataRepo.Create(data);

            return Ok(data);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UserEducationalProgrammeData data)
        {
            await userEducationalProgrammeDataRepo.Update(data);

            return Ok(data);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await userEducationalProgrammeDataRepo.Delete(id))
            {
                return Ok(id);
            }

            return BadRequest();
        }
    }
}
