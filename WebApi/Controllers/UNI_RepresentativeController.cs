using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.Repository;

namespace WebApi.Controllers
{
    public class UNI_RepresentativeController : Controller
    {
        private readonly IRepository<UNI_Representative> uni_representativeRepo;
        public UNI_RepresentativeController(IRepository<UNI_Representative> UNI_RepresentativeRepo)
        {
            uni_representativeRepo = UNI_RepresentativeRepo;
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get()
        {
            var uni_representative = await uni_representativeRepo.Get();

            return Ok(uni_representative);
        }
        [HttpGet("Get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var uni_representative = await uni_representativeRepo.Get(id);

            if (uni_representative != null)
            {
                return Ok(uni_representative);
            }

            return NotFound();
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] UNI_Representative uni_representative)
        {
            await uni_representativeRepo.Create(uni_representative);

            return Ok(uni_representative);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UNI_Representative uni_representative)
        {
            await uni_representativeRepo.Update(uni_representative);

            return Ok(uni_representative);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await uni_representativeRepo.Delete(id))
            {
                return Ok(id);
            }

            return BadRequest();
        }
    }
}
