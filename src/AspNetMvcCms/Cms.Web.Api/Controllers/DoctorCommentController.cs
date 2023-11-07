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
    public class DoctorCommentController : ControllerBase
    {
        private readonly IDoctorCommentService _dcommentService;
        private readonly IMapper _mapper;

        

        public DoctorCommentController(IDoctorCommentService dcommentService, IMapper mapper)
        {
            _dcommentService = dcommentService;
            _mapper = mapper;
        }



        // GET: api/Doctors
        [HttpGet]
        public IEnumerable<DoctorCommentEntity> GetAll()
        {
            var doctors = _dcommentService.GetAll();

            return doctors;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByDoctorId(int id)
        {
            var doctor = await _dcommentService.GetByIdAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }
            return Ok(doctor);
        }
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] DoctorCommentCreateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                var mapp = _mapper.Map<DoctorCommentEntity>(dto);
                var doctor = await _dcommentService.AddAsync(mapp);
                return Ok(doctor);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }

        // PUT: api/Doctors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] DoctorCommentUpdateDto dto)
        {
            if (dto.Id != id)
                return BadRequest();
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                var mapp = _mapper.Map<DoctorCommentEntity>(dto);
                var doctor = await _dcommentService.UpdateAsync(id, mapp);
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
            var isDeleted = await _dcommentService.DeleteAsync(id);
            if (!isDeleted)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}
