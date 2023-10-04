﻿using Cms.Data.Models.Entities;
using Cms.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cms.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IDataRepository<DoctorEntity> _repository;

        public DoctorsController(IDataRepository<DoctorEntity> repository)
        {
            _repository = repository;
        }

        // GET: api/Doctors
        [HttpGet]
        public IEnumerable<DoctorEntity> GetAll()
        {
            var doctors = _repository.GetAll();
            return doctors;
        }

        // GET: api/Doctors/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var doctor = await _repository.GetByIdAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }
            return Ok(doctor);
        }

        // POST: api/Doctors
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] DoctorEntity doctor)
        {
            if (doctor == null)
            {
                return BadRequest();
            }

            var createdDoctor = await _repository.AddAsync(doctor);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = createdDoctor.Id }, createdDoctor);
        }

        // PUT: api/Doctors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] DoctorEntity doctor)
        {
            if (doctor == null || id != doctor.Id)
            {
                return BadRequest();
            }

            var updatedDoctor = await _repository.UpdateAsync(id, doctor);
            if (updatedDoctor == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/Doctors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var isDeleted = await _repository.DeleteAsync(id);
            if (!isDeleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}