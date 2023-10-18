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
    public class DoctorCategoryController : ControllerBase
    {
        private readonly IDoctorCategoryService _doctorcategoryService;
   

        public DoctorCategoryController(IDoctorCategoryService appointmentService )
        {
            _doctorcategoryService = appointmentService;
            
        }
        [HttpGet("{id}")]
        public IEnumerable<DoctorCategoryEntity> GetByDoctorCategoryId(int id)
        {
            var doctorAppointments = _doctorcategoryService.GetByDoctorCategoryId(id);

            return doctorAppointments;
        }
        //[HttpGet]
        //public IEnumerable<DoctorCategoryEntity> GetAll()
        //{
        //    var doctors = _doctorcategoryService.GetAll();

        //    return doctors;
        //}
    }
}
