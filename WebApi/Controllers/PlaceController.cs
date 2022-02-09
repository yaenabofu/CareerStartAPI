using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.Repository;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlaceController : Controller
    {
        private readonly IRepository<Place> placeRepo;
        public PlaceController(IRepository<Place> PlaceRepo)
        {
            this.placeRepo = PlaceRepo;
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get()
        {
            var data = await placeRepo.Get();

            return Ok(data);
        }
        [HttpGet("Get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await placeRepo.Get(id);

            if (data != null)
            {
                return Ok(data);
            }

            return NotFound();
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] Place data)
        {
            await placeRepo.Create(data);

            return Ok(data);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] Place data)
        {
            await placeRepo.Update(data);

            return Ok(data);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await placeRepo.Delete(id))
            {
                return Ok(id);
            }

            return BadRequest();
        }
    }
}
