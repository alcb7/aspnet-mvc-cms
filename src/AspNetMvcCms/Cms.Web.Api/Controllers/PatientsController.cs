using AutoMapper;
using Cms.Data.Models.Entities;
using Cms.Services.Abstract;
using Cms.Web.Api.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cms.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientService _patientService;
        private readonly IMapper _mapper;

        public PatientsController(IMapper mapper, IPatientService patientService)
        {
            _mapper = mapper;
            _patientService = patientService;
        }

        // GET: api/Doctors
        [HttpGet]
        public IEnumerable<PatientEntity> GetAll()
        {
            var patients = _patientService.GetAll();

            return patients;
        }

        // GET: api/Doctors/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var patient = await _patientService.GetByIdAsync(id);
            if (patient == null)
            {
                return NotFound();
            }
            return Ok(patient);
        }

        // POST: api/Doctors
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] PatientCreateDto patientdto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                var mapp = _mapper.Map<PatientEntity>(patientdto);
                var patient = await _patientService.AddAsync(mapp);
                return Ok(patient);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }

        // PUT: api/Doctors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] PatientUpdateDto patientdto)
        {
            if (patientdto.Id != id)
                return BadRequest();
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                var patientmapp = _mapper.Map<PatientEntity>(patientdto);
                var patient = await _patientService.UpdateAsync(id, patientmapp);
                return Ok(patient);
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
            var isDeleted = await _patientService.DeleteAsync(id);
            if (!isDeleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
