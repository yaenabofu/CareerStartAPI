using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.Repository;

namespace WebApi.Controllers
{
    public class EducationalProgrammeController : Controller
    {
        private readonly IRepository<EducationalProgramme> educationalProgrammes;
        public EducationalProgrammeController(IRepository<EducationalProgramme> AcademicSupervisorRepo)
        {
            this.educationalProgrammes = AcademicSupervisorRepo;
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get()
        {
            var educationalProgramme = await educationalProgrammes.Get();

            return Ok(educationalProgramme);
        }
        [HttpGet("Get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var educationalProgramme = await educationalProgrammes.Get(id);

            if (educationalProgramme != null)
            {
                return Ok(educationalProgramme);
            }

            return NotFound();
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] EducationalProgramme educationalProgramme)
        {
            await educationalProgrammes.Create(educationalProgramme);

            return Ok(educationalProgramme);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] EducationalProgramme educationalProgramme)
        {
            await educationalProgrammes.Update(educationalProgramme);

            return Ok(educationalProgramme);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await educationalProgrammes.Delete(id))
            {
                return Ok(id);
            }

            return BadRequest();
        }
    }
}
