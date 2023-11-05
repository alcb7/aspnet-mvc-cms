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
        private readonly IFileService _fileService;

        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpPost]
        public async Task<IActionResult> UploadAsync(IFormFile formFile)
        {
            try
            {
                await _fileService.UploadFileAsync(formFile);
                return Ok("File Uploaded");
            }
            catch (Exception e)
            {

                return BadRequest(e);
            }

        }

        [HttpGet]
        public async Task<IActionResult> DownloadAsync([FromQuery] string fileName)
        {
            try
            {
                var response = await _fileService.DownloadFileAsync(fileName);
                return File(response.FileContent, response.ContentType, response.FileName);
            }
            catch (Exception e)
            {

                return BadRequest(e);
            }

        }

    }
}
