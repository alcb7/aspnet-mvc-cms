using Cms.Data.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Cms.Web.Mvc.Admin.Controllers
{
    public class BlogsController : Controller
    {
        private readonly HttpClient _httpClient;

     
        private readonly string _apiBlog = "https://localhost:7188/api/Blogs";
        public BlogsController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
       
        public async Task<ActionResult> GetBlogs()
        {
            var model = await _httpClient.GetFromJsonAsync<List<BlogEntity>>(_apiBlog);

            return View(model);
        }
    }
}

