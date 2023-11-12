using Cms.Data.Models.Entities;
using Cms.Web.Mvc.Patient.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace Cms.Web.Mvc.Patient.Controllers
{

    public class PatientCommentController : Controller
    {


        private readonly HttpClient _httpClient;

        private readonly string _apipComments = "https://localhost:7188/api/PatientComment";

        public PatientCommentController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ActionResult> GetPComments()
        {

            var model = await _httpClient.GetFromJsonAsync<List<PatientCommentEntity>>(_apipComments);
            return View(model);
        }

        [HttpGet]
        public IActionResult AddPComment()
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
        public async Task<ActionResult> AddPComment(PatientCommentViewModel dto)
        {

            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            var userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.PrimarySid));
            dto.PatientId = userId;


            var pcommentEntity = new PatientCommentEntity
            {


                Title = dto.Title,
                Description = dto.Description,
                PatientId = userId,





            };
            var response = await _httpClient.PostAsJsonAsync(_apipComments, pcommentEntity);
            if (response.IsSuccessStatusCode)
            {
                ViewBag.Message = "Blog Başarıyla kaydedildi.";
				return RedirectToAction("Index", "About");
			}

            return View(dto);

        }
    }

}
