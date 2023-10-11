using Cms.Data.Models.Entities;
using Cms.Web.Mvc.Admin.DTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;

namespace Cms.Web.Mvc.Admin.Controllers
{
    public class BlogsController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiBlog; // API URL'sini burada tanımlayın

        public BlogsController(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _apiBlog = "https://localhost:7188/api/Blogs"; // API URL'sini burada ayarlayın
        }

        public async Task<ActionResult> GetBlogs()
        {
            var model = await _httpClient.GetFromJsonAsync<List<BlogEntity>>(_apiBlog);
            return View(model);
        }
        
        [HttpPost]
        public async Task<ActionResult> AddBlogs([FromBody] BlogCreateDto dto)
        {
            // Öncelikle customer nesnesini BlogEntity'ye çevirin veya uygun veri yapısına dönüştürün
            var blogEntity = new BlogEntity
            {
                // CustomerModel'den alınan verileri BlogEntity'ye kopyalayın
                // Örnek: blogEntity.Name = customer.Name;
                Title = dto.Title,
                Description =dto.Description,
                BlogCategoryId = dto.BlogCategoryId
                
            };

            HttpResponseMessage response = await _httpClient.PostAsJsonAsync(_apiBlog, blogEntity);

            if (response.IsSuccessStatusCode)
            {
                // Başarılı ekleme işlemi
                return RedirectToAction("Index");
            }
            else
            {
                // Hata durumu
                ModelState.AddModelError(string.Empty, "Ekleme işlemi başarısız.");
                return View(dto);
            }
        }
        //[HttpPost]
        //public async Task<ActionResult> AddBlogs(CustomerModel customer)
        //{
        //    var model = await _httpClient.PostAsJsonAsync<BlogEntity>(_apiBlog);

        //    if (model.IsSuccessStatusCode)
        //    {
        //        // Başarılı ekleme işlemi
        //        return RedirectToAction("Index");
        //    }
        //    else
        //    {
        //        // Hata durumu
        //        ModelState.AddModelError(string.Empty, "Ekleme işlemi başarısız.");
        //        return View(customer);
        //    }
        //}
        //[HttpPost]
        //public ActionResult AddBlog(BlogEntity blog)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        // Blog verilerini veritabanına kaydedin
        //        // Örnek olarak Entity Framework kullanımı:
        //        // dbContext.Blogs.Add(blog);
        //        // dbContext.SaveChanges();
        //        return RedirectToAction("GetBlogs", "Blogs"); // Blog listesine geri dön
        //    }
        //    return View(blog); // Hata durumunda formu tekrar göster
        //}
        //    [HttpPost]
        //    public async Task<ActionResult> AddBlogs(BlogEntity blog)
        //    {
        //        try
        //        {
        //            if (ModelState.IsValid)
        //            {
        //                var jsonBlog = JsonConvert.SerializeObject(blog);
        //                var content = new StringContent(jsonBlog, Encoding.UTF8, "application/json");

        //                var response = await _httpClient.PostAsync(_apiBlog, content); // API URL'sini kullanarak POST isteği yapın

        //                if (response.IsSuccessStatusCode)
        //                {
        //                    TempData["SuccessMessage"] = "Blog başarıyla eklendi ve API'ye gönderildi.";
        //                    return RedirectToAction("GetBlogs", "Blogs");
        //                }
        //                else
        //                {
        //                    TempData["ErrorMessage"] = "Blog eklenirken bir hata oluştu. API'ye gönderme başarısız.";
        //                }
        //            }
        //            else
        //            {
        //                ModelState.AddModelError(string.Empty, "Blog verileri geçerli değil. Lütfen gerekli alanları doldurun.");
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            TempData["ErrorMessage"] = "Blog eklenirken bir hata oluştu. Lütfen tekrar deneyin.";
        //        }

        //        return View(blog);
        //    }
        //}

    }

}