using AutoMapper;
using Azure.Core;
using Cms.Data.Models.Entities;
using Cms.Services.Abstract;
using Cms.Web.Api.DTOs;
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
        private readonly IDoctorService _doctorService;
        private readonly IMapper _mapper;

        public DoctorsController(IMapper mapper,IDoctorService doctorService)
        {
            _mapper = mapper;
            _doctorService = doctorService;
        }

        // GET: api/Doctors
        [HttpGet]
        public IEnumerable<DoctorEntity> GetAll()
        {
            var doctors = _doctorService.GetAll();
           
            return doctors;
        }

        // GET: api/Doctors/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var doctor = await _doctorService.GetByIdAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }
            return Ok(doctor);
        }

        // POST: api/Doctors
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] DoctorCreateDto dto)
        {
            var doctor = _mapper.Map<DoctorEntity>(dto);
            if (doctor == null)
            {
                return BadRequest();
            }
         
            var createdDoctor = await _doctorService.AddAsync(doctor);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = createdDoctor.Id }, createdDoctor);
        }

        // PUT: api/Doctors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] DoctorUpdateDto dto)
        {
            var doctor = _mapper.Map<DoctorEntity>(dto);
         
            if (doctor == null || id != doctor.Id)
            {
                return BadRequest();
            }

            var updatedDoctor = await _doctorService.UpdateAsync(id, doctor);
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
            var isDeleted = await _doctorService.DeleteAsync(id);
            if (!isDeleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
