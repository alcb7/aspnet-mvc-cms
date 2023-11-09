using Cms.Data.Models.Entities;
using Cms.Web.Mvc.Patient.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Cms.Web.Mvc.Patient.Controllers
{
    public class BlogController : Controller
    {
        private readonly HttpClient _httpClient;

        private readonly string _apiBlog = "https://localhost:7188/api/Blogs/";
        private readonly string _apiComment = "https://localhost:7188/api/Comment/";
        public BlogController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ActionResult> Index()
        {
            var model = await _httpClient.GetFromJsonAsync<List<BlogEntity>>(_apiBlog);

            return View(model);
        }

        public async Task<ActionResult> Detail(int id)
        {
       

            var model = await _httpClient.GetFromJsonAsync<BlogEntity>(_apiBlog+id);
            var model1 = await _httpClient.GetFromJsonAsync<List<CommentEntity>>(_apiComment);
            var model2 = model1.Where(a => a.BlogId == id).ToList();



            var viewModel = new BlogViewModel
            {
                Blogs = model,
                Comments = model2,

            };


            return View(viewModel);
        }


        [HttpPost]
        public async Task<ActionResult> Detail(BlogViewModel dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            var userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.PrimarySid));
            dto.Comment.PatientId = userId;

            var blogcommentEntity = new CommentEntity
            {
                Text = dto.Comment.Text,
                PatientId = userId,
                BlogId = dto.Comment.BlogId,
            };

            var response = await _httpClient.PostAsJsonAsync(_apiComment, blogcommentEntity);

            if (response.IsSuccessStatusCode)
            {
                ViewBag.Message = "Blog Başarıyla kaydedildi.";

                // Yorum eklendikten sonra sayfayı güncelle
                return RedirectToAction("Detail", new { id = dto.Comment.BlogId });
            }

            return View(dto);
        }

    }
}
