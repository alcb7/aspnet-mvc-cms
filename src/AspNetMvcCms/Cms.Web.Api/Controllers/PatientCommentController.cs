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
	public class PatientCommentController : ControllerBase
	{
		private readonly IPatientCommentService _pcommentService;
		private readonly IMapper _mapper;

		public PatientCommentController(IPatientCommentService pcommentService, IMapper mapper)
		{
			_pcommentService = pcommentService;
			_mapper = mapper;
		}
        //[HttpGet("{id}")]
        //public IEnumerable<PatientCommentEntity> GetByDoctorId(int id)
        //{
        //    var doctorAppointments = _pcommentService.GetByDoctorId(id);

        //    return doctorAppointments;
        //}


        [HttpGet("{id}")]
        public async Task<IActionResult> GetByDoctorId(int id)
        {
            var doctor = await _pcommentService.GetByIdAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }
            return Ok(doctor);
        }



        // GET: api/Doctors
        [HttpGet]
		public IEnumerable<PatientCommentEntity> GetAll()
		{
			var patients = _pcommentService.GetAll();

			return patients;
		}
		[HttpPost]
		public async Task<IActionResult> AddAsync([FromBody] PatientCommentDto dto)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest();
			}
			try
			{
				var mapp = _mapper.Map<PatientCommentEntity>(dto);
				var doctor = await _pcommentService.AddAsync(mapp);
				return Ok(doctor);
			}
			catch (Exception e)
			{

				return BadRequest(e.Message);
			}

		}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var isDeleted = await _pcommentService.DeleteAsync(id);
            if (!isDeleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
