using AutoMapper;
using Cms.Data.Models.Entities;
using Cms.Services.Abstract;
using Cms.Services.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cms.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorCommentController : ControllerBase
    {
        private readonly IDoctorCommentService _dcommentService;
       

        public DoctorCommentController(IDoctorCommentService dcommentService)
        {
            _dcommentService = dcommentService;
        }



        // GET: api/Doctors
        [HttpGet]
        public IEnumerable<DoctorCommentEntity> GetAll()
        {
            var doctors = _dcommentService.GetAll();

            return doctors;
        }

        [HttpGet("{id}")]
        public IEnumerable<DoctorCommentEntity> GetByDoctorId(int id)
        {
            var doctorAppointments = _dcommentService.GetByDoctorId(id);

            return doctorAppointments;
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
