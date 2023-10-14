using AutoMapper;
using Cms.Data.Models.Entities;
using Cms.Services.Abstract;
using Cms.Services.Concrete;
using Cms.Web.Api.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cms.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IMapper _mapper;

        public AppointmentController(IAppointmentService appointmentService, IMapper mapper)
        {
            _appointmentService = appointmentService;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<AppointmentEntity> GetAll()
        {
            var doctors = _appointmentService.GetAll();

            return doctors;
        }

        //// GET: api/Doctors/5
        ////[HttpGet("{id}")]
        ////public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        ////{
        ////    var doctor = await _appointmentService.GetByIdAsync(id);
        ////    if (doctor == null)
        ////    {
        ////        return NotFound();
        ////    }
        ////    return Ok(doctor);
        ////}
		[HttpGet("{id}")]
		public IEnumerable<AppointmentEntity> GetByDoctorId(int id)
		{
			var doctorAppointments = _appointmentService.GetByDoctorId(id);

			return doctorAppointments;
		}

		// POST: api/Doctors
		[HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] AppointmentCreateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                var mapp = _mapper.Map<AppointmentEntity>(dto);
                var doctor = await _appointmentService.AddAsync(mapp);
                return Ok(doctor);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }

        // PUT: api/Doctors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] AppointmentUpdateDto dto)
        {
            if (dto.Id != id)
                return BadRequest();
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                var mapp = _mapper.Map<AppointmentEntity>(dto);
                var doctor = await _appointmentService.UpdateAsync(id, mapp);
                return Ok(doctor);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        // DELETE: api/Doctors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var isDeleted = await _appointmentService.DeleteAsync(id);
            if (!isDeleted)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}
