using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.Repository;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IRepository<User> userRepo;
        public UserController(IRepository<User> UserRepo)
        {
            userRepo = UserRepo;
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get()
        {
            var users = await userRepo.Get();

            return Ok(users);
        }
        [HttpGet("Get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var user = await userRepo.Get(id);

            if (user != null)
            {
                return Ok(user);
            }

            return NotFound();
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] User obj)
        {
            await userRepo.Create(obj);

            return Ok(obj);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] User obj)
        {
            await userRepo.Update(obj);

            return Ok(obj);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await userRepo.Delete(id))
            {
                return Ok(id);
            }

            return BadRequest();
        }
    }
}
