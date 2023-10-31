using Cms.Data.Models.Entities;
using Cms.Web.Mvc.Patient.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Cms.Web.Mvc.Patient.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient _httpClient;

        private readonly string _apiDComment = "https://localhost:7188/api/DoctorComment";

        private readonly string _apiDoctor = "https://localhost:7188/api/Doctors";
        private readonly string _apiBlog = "https://localhost:7188/api/Blogs";
        private readonly string _apiDepartments = "https://localhost:7188/api/Departments";
        private readonly string _apiPatient = "https://localhost:7188/api/Patients";
	


		public HomeController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ActionResult> Index()
        {
            var model = await _httpClient.GetFromJsonAsync<List<DoctorCommentEntity>>(_apiDComment);
            var model1 = await _httpClient.GetFromJsonAsync<List<DoctorEntity>>(_apiDoctor);
            var model2 = await _httpClient.GetFromJsonAsync<List<BlogEntity>>(_apiBlog);
            var model3 = await _httpClient.GetFromJsonAsync<List<DepartmentEntity>>(_apiDepartments);
            var model4 = await _httpClient.GetFromJsonAsync<List<PatientEntity>>(_apiPatient);



            var viewModel = new HomeViewModel
            {
                DoctorComments = model,
                Doctors = model1,
                Blogs = model2,
                Departments = model3,
                Patients = model4
            };
               

            return View(viewModel);
            
        }

    }
}