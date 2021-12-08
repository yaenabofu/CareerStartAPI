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
    public class EventRequestController : Controller
    {
        private readonly IRepository<EventRequest> eventRequestRepo;
        public EventRequestController(IRepository<EventRequest> EventRequestRepo)
        {
            this.eventRequestRepo = EventRequestRepo;
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get()
        {
            var eventRequests = await eventRequestRepo.Get();

            return Ok(eventRequests);
        }
        [HttpGet("Get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var eventRequest = await eventRequestRepo.Get(id);

            if (eventRequest != null)
            {
                return Ok(eventRequest);
            }

            return NotFound();
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] EventRequest eventRequest)
        {
            await eventRequestRepo.Create(eventRequest);

            return Ok(eventRequest);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] EventRequest eventRequest)
        {
            await eventRequestRepo.Update(eventRequest);

            return Ok(eventRequest);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await eventRequestRepo.Delete(id))
            {
                return Ok(id);
            }

            return BadRequest();
        }
    }
}
