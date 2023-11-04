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
    public class BlogCategoriesController : ControllerBase
    {
        private readonly IDepartmentService _bcategoriesService;
        private readonly IMapper _mapper;

        public BlogCategoriesController(IDepartmentService departmentService, IMapper mapper)
        {
            _bcategoriesService = departmentService;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<DepartmentEntity> GetAll()
        {
            var doctors = _bcategoriesService.GetAll();

            return doctors;
        }

        //GET: api/Doctors/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var doctor = await _bcategoriesService.GetByIdAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }
            return Ok(doctor);
        }

        // POST: api/Doctors
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] DepartmentCreateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                var mapp = _mapper.Map<DepartmentEntity>(dto);
                var doctor = await _bcategoriesService.AddAsync(mapp);
                return Ok(doctor);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }

        // PUT: api/Doctors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] DepartmentUpdateDto dto)
        {
            if (dto.Id != id)
                return BadRequest();
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                var mapp = _mapper.Map<DepartmentEntity>(dto);
                var doctor = await _bcategoriesService.UpdateAsync(id, mapp);
                return Ok(doctor);
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
            var isDeleted = await _bcategoriesService.DeleteAsync(id);
            if (!isDeleted)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}
