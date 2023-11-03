using Cms.Data.Models.Entities;
using Cms.Web.Mvc.Patient.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Cms.Web.Mvc.Patient.Controllers
{
	
	public class PatientCommentController : Controller
	{
		
		
			private readonly HttpClient _httpClient;

			private readonly string _apipComments = "https://localhost:7188/api/PatientComments";

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
				return View();
			}
			[HttpPost]
			public async Task<ActionResult> AddPComment(PatientCommentEntity dto)
			{
				var userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.PrimarySid));

				if (!ModelState.IsValid)
				{
					return View(dto);
				}


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
				}

				return View(dto);

			}
		}	
	
}
