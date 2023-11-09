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
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;
        private readonly IMapper _mapper;
      

        public CommentController(ICommentService commentService, IMapper mapper)
        {
            _commentService = commentService;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<CommentEntity> GetAll()
        {
            var comments = _commentService.GetAll();

            return comments;
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] CommentCreateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                var mapp = _mapper.Map<CommentEntity>(dto);
                var doctor = await _commentService.AddAsync(mapp);
                return Ok(doctor);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }
    }
}
