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
    public class VacancyController : Controller
    {
        private readonly IRepository<Vacancy> vacancyRepo;
        public VacancyController(IRepository<Vacancy> VacancyRepo)
        {
            this.vacancyRepo = VacancyRepo;
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get()
        {
            var vacancies = await vacancyRepo.Get();

            return Ok(vacancies);
        }
        [HttpGet("Get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var getEvent = await vacancyRepo.Get(id);

            if (getEvent != null)
            {
                return Ok(getEvent);
            }

            return NotFound();
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] Vacancy vacancy)
        {
            await vacancyRepo.Create(vacancy);

            return Ok(vacancy);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] Vacancy vacancy)
        {
            await vacancyRepo.Update(vacancy);

            return Ok(vacancy);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await vacancyRepo.Delete(id))
            {
                return Ok(id);
            }

            return BadRequest();
        }
    }
}
