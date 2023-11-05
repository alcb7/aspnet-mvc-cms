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
    public class ServiceBlogController : ControllerBase
    {
        private readonly IDataRepository<ServiceBlogEntity> _sblogService;
        private readonly IMapper _mapper;


        public ServiceBlogController(IDataRepository<ServiceBlogEntity> sblogService, IMapper mapper)
        {
            _sblogService = sblogService;
            _mapper = mapper;
        }


        // GET: api/Doctors
        [HttpGet]
        public IEnumerable<ServiceBlogEntity> GetAll()
        {
            var doctors = _sblogService.GetAll();

            return doctors;
        }


        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] ServiceBlogCreateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                var mapp = _mapper.Map<ServiceBlogEntity>(dto);
                var doctor = await _sblogService.AddAsync(mapp);
                return Ok(doctor);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }


        // PUT: api/Doctors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] ServiceBlogUpdateDto dto)
        {
            if (dto.Id != id)
                return BadRequest();
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                var mapp = _mapper.Map<ServiceBlogEntity>(dto);
                var doctor = await _sblogService.UpdateAsync(id, mapp);
                return Ok(doctor);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
		[HttpGet("{id}")]
		public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
		{
			var doctor = await _sblogService.GetByIdAsync(id);
			if (doctor == null)
			{
				return NotFound();
			}
			return Ok(doctor);
		}

	}
}