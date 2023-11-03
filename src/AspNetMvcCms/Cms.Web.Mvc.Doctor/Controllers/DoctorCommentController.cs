using Cms.Data.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Cms.Web.Mvc.Doctor.Controllers
{
    [Authorize]
    
    public class DoctorCommentController : Controller
    {
        private readonly HttpClient _httpClient;

        private readonly string _apiDComment = "https://localhost:7188/api/DoctorComment";

        public DoctorCommentController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet]
        public async Task<ActionResult> GetDoctorComment()
        {
            var userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.PrimarySid));

			var response = await _httpClient.GetAsync($"{_apiDComment}/{userId}");
			if (!response.IsSuccessStatusCode)
			{
				return StatusCode((int)response.StatusCode);
			}
			var model = await response.Content.ReadFromJsonAsync<List<DoctorCommentEntity>>();
			return View(model);
        }
		

	}
}
