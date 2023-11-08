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
        
        [HttpGet]
        public IActionResult AddBlogComment()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Auth");
            }
            else
            {
                // Kullanıcı oturum açmamışsa oturum açma sayfasına yönlendir
                return View();
            }



        }
        [HttpPost]
        public async Task<ActionResult> AddBlogComment(BlogCommentViewModel dto, [FromRoute] int id)
        {

            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            var userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.PrimarySid));
            dto.PatientId = userId;
            dto.BlogId = id;


            var blogcommentEntity = new CommentEntity
            {


                Text = dto.Text,
                PatientId = userId,
                BlogId=id




            };
            var response = await _httpClient.PostAsJsonAsync(_apiComment, blogcommentEntity);
            if (response.IsSuccessStatusCode)
            {
                ViewBag.Message = "Blog Başarıyla kaydedildi.";
            }

            return View(dto);

        }
    }
}
