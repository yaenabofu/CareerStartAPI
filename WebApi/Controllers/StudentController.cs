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
    public class StudentController : Controller
    {
        private readonly IRepository<Student> studentRepo;
        public StudentController(IRepository<Student> StudentRepo)
        {
            this.studentRepo = StudentRepo;
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get()
        {
            var students = await studentRepo.Get();

            return Ok(students);
        }
        [HttpGet("Get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var student = await studentRepo.Get(id);

            if (student != null)
            {
                return Ok(student);
            }

            return NotFound();
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] Student student)
        {
            await studentRepo.Create(student);

            return Ok(student);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] Student student)
        {
            await studentRepo.Update(student);

            return Ok(student);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await studentRepo.Delete(id))
            {
                return Ok(id);
            }

            return BadRequest();
        }
    }
}
