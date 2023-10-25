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
    public class ContactController : ControllerBase
    {
        private readonly IDataRepository<ContactEntity> _contactService;

        public ContactController(IDataRepository<ContactEntity> contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public IEnumerable<ContactEntity> GetAll()
        {
            var contacts = _contactService.GetAll();

            return contacts;
        }
       
        [HttpPost]
        public async Task<IActionResult> AddAsync(ContactEntity entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
             
                var doctor = await _contactService.AddAsync(entity);
                return Ok(doctor);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }
    }
}
