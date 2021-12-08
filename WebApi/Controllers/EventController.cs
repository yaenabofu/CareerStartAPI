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
    public class EventController : Controller
    {
        private readonly IRepository<Event> eventRepo;
        public EventController(IRepository<Event> EventRepo)
        {
            this.eventRepo = EventRepo;
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get()
        {
            var events = await eventRepo.Get();

            return Ok(events);
        }
        [HttpGet("Get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var getEvent = await eventRepo.Get(id);

            if (getEvent != null)
            {
                return Ok(getEvent);
            }

            return NotFound();
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] Event onCreateEvent)
        {
            await eventRepo.Create(onCreateEvent);

            return Ok(onCreateEvent);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] Event onUpdateEvent)
        {
            await eventRepo.Update(onUpdateEvent);

            return Ok(onUpdateEvent);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await eventRepo.Delete(id))
            {
                return Ok(id);
            }

            return BadRequest();
        }
    }
}
