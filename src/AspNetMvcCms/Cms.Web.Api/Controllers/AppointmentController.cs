using Cms.Data.Models.Entities;
using Cms.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cms.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IDataRepository<AppointmentEntity> _appointmentService;

        public AppointmentController(IDataRepository<AppointmentEntity> appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpGet]
        public IEnumerable<AppointmentEntity> GetAll()
        {
            var doctors = _appointmentService.GetAll();

            return doctors;
        }


    }
}
