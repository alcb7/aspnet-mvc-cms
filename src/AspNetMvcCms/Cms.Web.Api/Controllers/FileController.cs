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
        private readonly string _apiFileStoragePath = Path.Combine(Directory.GetCurrentDirectory(), "Uploads", "files");

        [HttpPost]
        [Route("upload")]
        public async Task<IActionResult> Upload([FromForm] IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("Dosya seçilmedi.");

            var filePath = Path.Combine(_apiFileStoragePath, file.FileName);

            if (!Directory.Exists(_apiFileStoragePath))
            {
                Directory.CreateDirectory(_apiFileStoragePath);
            }

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            return Ok(new { filePath });
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