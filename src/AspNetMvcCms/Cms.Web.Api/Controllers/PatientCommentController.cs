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
	public class PatientCommentController : ControllerBase
	{
		private readonly IPatientCommentService _pcommentService;
		private readonly IMapper _mapper;

		public PatientCommentController(IPatientCommentService pcommentService, IMapper mapper)
		{
			_pcommentService = pcommentService;
			_mapper = mapper;
		}






		// GET: api/Doctors
		[HttpGet]
		public IEnumerable<PatientCommentEntity> GetAll()
		{
			var patients = _pcommentService.GetAll();

			return patients;
		}
		[HttpPost]
		public async Task<IActionResult> AddAsync([FromBody] PatientCommentDto dto)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest();
			}
			try
			{
				var mapp = _mapper.Map<PatientCommentEntity>(dto);
				var doctor = await _pcommentService.AddAsync(mapp);
				return Ok(doctor);
			}
			catch (Exception e)
			{

				return BadRequest(e.Message);
			}

		}
	}
}
