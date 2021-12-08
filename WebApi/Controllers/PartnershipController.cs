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
    public class PartnershipController : Controller
    {
        private readonly IRepository<Partnership> partnershipRepo;
        public PartnershipController(IRepository<Partnership> Partnership)
        {
            this.partnershipRepo = Partnership;
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get()
        {
            var partnerships = await partnershipRepo.Get();

            return Ok(partnerships);
        }
        [HttpGet("Get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var partnership = await partnershipRepo.Get(id);

            if (partnership != null)
            {
                return Ok(partnership);
            }

            return NotFound();
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] Partnership partnership)
        {
            await partnershipRepo.Create(partnership);

            return Ok(partnership);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] Partnership partnership)
        {
            await partnershipRepo.Update(partnership);

            return Ok(partnership);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await partnershipRepo.Delete(id))
            {
                return Ok(id);
            }

            return BadRequest();
        }
    }
}
