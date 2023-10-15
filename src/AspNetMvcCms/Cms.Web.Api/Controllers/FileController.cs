using Cms.Data.Context;
using Cms.Data.Models.Entities;
using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cms.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        public AppDbContext DbContext { get; }

        public FileController(AppDbContext dbContext)
        {
            DbContext = dbContext;
        }

        [HttpGet("get-files")]
        public async Task<IActionResult> GetFileList()
        {
            var files = await DbContext.Files
                .Select(f => new
                {
                    f.Id,
                    f.FileName,
                    f.MimeType
                }).ToListAsync();

            return Ok(files);
        }

        [HttpGet("get-file/{id}")]
        public async Task<IActionResult> GetFile([FromRoute] int id)
        {
            var file = await DbContext.Files.SingleOrDefaultAsync(x => x.Id == id);
            if (file is null)
            {
                return NotFound();
            }

            return File(file.Data, file.MimeType);
        }

        [HttpPost("post-file")]
        public async Task<IActionResult> PostFile(IFormFile file)
        {
            var fileEntity = new FileEntity
            {
                FileName = file.FileName,
                MimeType = file.ContentType
            };

            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                fileEntity.Data = ms.ToArray();
            }

            DbContext.Files.Add(fileEntity);
            await DbContext.SaveChangesAsync();


            return Ok(new {
                fileEntity.Id
            }); // { id : 3 }
        }
    }
}
