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
    public class ResponseController : Controller
    {
        private readonly IRepository<Response> responseRepo;
        public ResponseController(IRepository<Response> ResponseRepo)
        {
            this.responseRepo = ResponseRepo;
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get()
        {
            var responses = await responseRepo.Get();

            return Ok(responses);
        }
        [HttpGet("Get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await responseRepo.Get(id);

            if (response != null)
            {
                return Ok(response);
            }

            return NotFound();
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] Response response)
        {
            await responseRepo.Create(response);

            return Ok(response);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] Response response)
        {
            await responseRepo.Update(response);

            return Ok(response);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await responseRepo.Delete(id))
            {
                return Ok(id);
            }

            return BadRequest();
        }
    }
}
