using Cms.Data.Models.Entities;
using Cms.Services.Abstract;
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
    }
}
