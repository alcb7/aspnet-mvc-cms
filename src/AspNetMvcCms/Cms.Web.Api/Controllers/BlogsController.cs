using AutoMapper;
using Cms.Data.Models.Entities;
using Cms.Services.Abstract;
using Cms.Web.Api.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cms.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly IBlogService _blogService;
        private readonly IMapper _mapper;

        public BlogsController(IMapper mapper, IBlogService blogService)
        {
            _mapper = mapper;
            _blogService = blogService;
        }

        // GET: api/Doctors
        [HttpGet]
        public async Task<IEnumerable<BlogResponseDto>> GetAll()
        {
            var blogQuery = _blogService.GetAll();

            var blogs = await blogQuery
                .Include(b => b.Comments)
                .Select(b => new BlogResponseDto
                {
                    Id = b.Id,
                    Title = b.Title,
                    Description = b.Description,
                    ResimDosyaAdi = b.ResimDosyaAdi,
                    BlogCategoryId = b.BlogCategoryId,
                    Comments = b.Comments.Select(c => new CommentResponseDto
                    {
                        Id = c.Id,
                        BlogId = c.BlogId,
                        Text = c.Text,
                    }).ToList()
                })
                .ToListAsync();

            return blogs;
        }



        //GET: api/Doctors/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var doctor = await _blogService.GetByIdAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }
            return Ok(doctor);
        }

        // POST: api/Doctors
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] BlogCreateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                var mapp = _mapper.Map<BlogEntity>(dto);
                var doctor = await _blogService.AddAsync(mapp);
                return Ok(doctor);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }

        // PUT: api/Doctors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] BlogUpdateDto dto)
        {
            if (dto.Id != id)
                return BadRequest();
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                var mapp = _mapper.Map<BlogEntity>(dto);
                var doctor = await _blogService.UpdateAsync(id, mapp);
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
            var isDeleted = await _blogService.DeleteAsync(id);
            if (!isDeleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
