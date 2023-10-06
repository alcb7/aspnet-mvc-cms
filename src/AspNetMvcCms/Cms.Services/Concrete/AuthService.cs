using Cms.Data.Context;
using Cms.Data.Models.Entities;
using Cms.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Services.Concrete
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _appDbContext;
        private readonly IDataRepository<DoctorEntity> _doctorrepository;
        private readonly IDataRepository<PatientEntity> _patientrepository;
        private readonly IDataRepository<AdminEntity> _repository;


        public AuthService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<bool> AuthenticateAsync(string username, string password)
        {
            // Kullanıcı bilgilerini veritabanından alın ve doğrulama işlemini gerçekleştirin
            var user = await _appDbContext.GetUserByUsername(username);

            if (user != null && user.Password == password)
            {
                // Kullanıcı başarıyla doğrulandı, Cookie oluşturun ve kullanıcıyı oturum açık olarak işaretleyin
                var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                // Diğer kullanıcı bilgileri için gerekli claim'leri ekleyebilirsiniz.
            };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = true, // Kullanıcıyı kalıcı olarak oturum açık yapmak isterseniz true yapabilirsiniz.
                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

                return true;
            }

            return false;
        }
    }

}
