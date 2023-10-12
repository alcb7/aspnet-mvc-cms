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
	public class DepartmentsController : ControllerBase
	{
		private readonly IDepartmentService _departmentService;
		private readonly IMapper _mapper;

		public DepartmentsController(IDepartmentService departmentService, IMapper mapper)
		{
			_departmentService = departmentService;
			_mapper = mapper;
		}

		[HttpGet]
		public IEnumerable<DepartmentEntity> GetAll()
		{
			var doctors = _departmentService.GetAll();

			return doctors;
		}

		//GET: api/Doctors/5
		[HttpGet("{id}")]
		public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
		{
			var doctor = await _departmentService.GetByIdAsync(id);
			if (doctor == null)
			{
				return NotFound();
			}
			return Ok(doctor);
		}

		// POST: api/Doctors
		[HttpPost]
		public async Task<IActionResult> AddAsync([FromBody] AppointmentCreateDto dto)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest();
			}
			try
			{
				var mapp = _mapper.Map<DepartmentEntity>(dto);
				var doctor = await _departmentService.AddAsync(mapp);
				return Ok(doctor);
			}
			catch (Exception e)
			{

				return BadRequest(e.Message);
			}

		}

		// PUT: api/Doctors/5
		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateAsync(int id, [FromBody] AppointmentUpdateDto dto)
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
				var doctor = await _departmentService.UpdateAsync(id, mapp);
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
			var isDeleted = await _departmentService.DeleteAsync(id);
			if (!isDeleted)
			{
				return NotFound();
			}

			return NoContent();
		}

	}
}
