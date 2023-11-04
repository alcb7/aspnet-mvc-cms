using Cms.Data.Models.Entities;
using Cms.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Services.Concrete
{
    public class BlogCategoriesService : IBlogCategoriesService
    {
        private readonly IDataRepository<BlogCategoryEntity> _adminrepository;

        public BlogCategoriesService(IDataRepository<BlogCategoryEntity> adminrepository)
        {
            _adminrepository = adminrepository;

        }

        public async Task<BlogCategoryEntity> AddAsync(BlogCategoryEntity entity)
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

        public IQueryable<BlogCategoryEntity> GetAll()
        {
            // Tüm doktorları almak için Repository kullanılır.
            return _adminrepository.GetAll();
            //return _appDbContext.Doctors
            //    .Include(d => d.Category);


        }

        public async Task<BlogCategoryEntity?> GetByIdAsync(int id)
        {
            // Veritabanından doktoru ID'ye göre almak için Repository kullanılır.
            return await _adminrepository.GetByIdAsync(id);
        }

        public async Task<BlogCategoryEntity?> UpdateAsync(int id, BlogCategoryEntity entity)
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
