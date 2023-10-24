using AutoMapper;
using Cms.Data.Models.Entities;
using Cms.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cms.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorCategoryController : ControllerBase
    {
        private readonly IDoctorCategoryService _doctorService;
      

        public DoctorCategoryController(IDoctorCategoryService doctorService)
        {
          
            _doctorService = doctorService;
        }

        // GET: api/Doctors
        [HttpGet]
        public IEnumerable<DoctorCategoryEntity> GetAll()
        {
            var doctors = _doctorService.GetAll();

            return doctors;
        }
    }
}
