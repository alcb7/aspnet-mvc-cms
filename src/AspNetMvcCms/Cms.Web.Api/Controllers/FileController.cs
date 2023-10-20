using Cms.Data.Context;
using Cms.Data.Models.Entities;
using Cms.Services.Abstract;
using Cms.Services.Concrete;
using Cms.Web.Api.DTOs;
using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace Cms.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
		private readonly IFileService<FileEntity> _fileService;

		public FileController(IFileService<FileEntity> fileService)
		{
			_fileService = fileService;
        }

        
		[HttpGet("get-files")]
		public IEnumerable<FileEntity> GetFileList()
		{
			var files = _fileService.GetFileList();

			return files;
        }



        [HttpGet("get-file/{id}")]
        public async Task<IActionResult> GetFile(int id)
        {
            var doctorAppointments = await _fileService.GetFile(id);

			return Ok(doctorAppointments);
        }



  //      [HttpPost("post-file")]
  //      public async Task<IActionResult> PostFile(IFormFile file)
  //      {
  //          var fileEntity = new FileEntity
  //          {
  //              FileName = file.FileName,
  //              MimeType = file.ContentType
  //          };

  //          using (var ms = new MemoryStream())
  //          {
  //              file.CopyTo(ms);
  //              fileEntity.Data = ms.ToArray();
  //          }

  //          DbContext.Files.Add(fileEntity);
  //          await DbContext.SaveChangesAsync();


  //          return Ok(new
  //          {
  //              fileEntity.Id
  //          }); // { id : 3 }
  //      }
		//[HttpPost]
		//public async Task<IActionResult> AddAsync([FromBody] AppointmentCreateDto dto)
		//{
		//	if (!ModelState.IsValid)
		//	{
		//		return BadRequest();
		//	}
		//	try
		//	{
		//		var mapp = _mapper.Map<AppointmentEntity>(dto);
		//		var doctor = await _appointmentService.AddAsync(mapp);
		//		return Ok(doctor);
		//	}
		//	catch (Exception e)
		//	{

		//		return BadRequest(e.Message);
		//	}

		//}
	}
}
