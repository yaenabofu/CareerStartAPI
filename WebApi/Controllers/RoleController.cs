using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.Repository;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : Controller
    {
        private readonly IRepository<Role> roleRepo;
        public RoleController(IRepository<Role> RoleRepo)
        {
            this.roleRepo = RoleRepo;
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get()
        {
            var data = await roleRepo.Get();

            return Ok(data);
        }
        [HttpGet("Get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await roleRepo.Get(id);

            if (data != null)
            {
                return Ok(data);
            }

            return NotFound();
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] Role data)
        {
            await roleRepo.Create(data);

            return Ok(data);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] Role data)
        {
            await roleRepo.Update(data);

            return Ok(data);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await roleRepo.Delete(id))
            {
                return Ok(id);
            }

            return BadRequest();
        }
    }
}
