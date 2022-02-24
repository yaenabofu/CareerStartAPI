﻿using Microsoft.AspNetCore.Mvc;
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
    public class PerformanceReviewController : Controller
    {
        private readonly IRepository<PerformanceReview> employmentRepo;
        public PerformanceReviewController(IRepository<PerformanceReview> EmploymentRepo)
        {
            this.employmentRepo = EmploymentRepo;
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get()
        {
            var employment = await employmentRepo.Get();

            return Ok(employment);
        }
        [HttpGet("Get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var employment = await employmentRepo.Get(id);

            if (employment != null)
            {
                return Ok(employment);
            }

            return NotFound();
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] PerformanceReview employment)
        {
            await employmentRepo.Create(employment);

            return Ok(employment);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] PerformanceReview employment)
        {
            await employmentRepo.Update(employment);

            return Ok(employment);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await employmentRepo.Delete(id))
            {
                return Ok(id);
            }

            return BadRequest();
        }
    }
}
