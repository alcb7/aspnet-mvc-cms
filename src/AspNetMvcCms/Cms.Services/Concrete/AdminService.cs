using Cms.Data.Context;
using Cms.Data.Models.Entities;
using Cms.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Services.Concrete
{
    public class AdminService : IAdminService
    {
        private readonly IDataRepository<AdminEntity> _adminrepository;
        
        public AdminService(IDataRepository<AdminEntity> adminrepository)
        {
            _adminrepository = adminrepository;
            
        }

        public async Task<AdminEntity> AddAsync(AdminEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            // Veritabanına yeni bir doktor eklemek için Repository kullanılır.
            return await _adminrepository.AddAsync(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            // Veritabanından doktoru ID'ye göre silmek için Repository kullanılır.
            return await _adminrepository.DeleteAsync(id);
        }

        public IQueryable<AdminEntity> GetAll()
        {
            // Tüm doktorları almak için Repository kullanılır.
            return _adminrepository.GetAll();
            //return _appDbContext.Doctors
            //    .Include(d => d.Category);


        }

        public async Task<AdminEntity?> GetByIdAsync(int id)
        {
            // Veritabanından doktoru ID'ye göre almak için Repository kullanılır.
            return await _adminrepository.GetByIdAsync(id);
        }

        public async Task<AdminEntity?> UpdateAsync(int id, AdminEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            // Veritabanında doktoru güncellemek için Repository kullanılır.
            return await _adminrepository.UpdateAsync(id, entity);
        }
    }
}
