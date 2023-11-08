using Cms.Data.Models.Entities;
using Cms.Services.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Services.Concrete
{
    public class CommentService : ICommentService
    {
        private readonly IDataRepository<CommentEntity> _adminrepository;

        public CommentService(IDataRepository<CommentEntity> adminrepository)
        {
            _adminrepository = adminrepository;

        }

        public async Task<CommentEntity> AddAsync(CommentEntity entity)
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

        public IQueryable<CommentEntity> GetAll()
        {
            // Tüm doktorları almak için Repository kullanılır.
            return _adminrepository.GetAll()
                .Include(d => d.Patient);
            //return _appDbContext.Doctors
            //    .Include(d => d.Category);


        }

        public async Task<CommentEntity?> GetByIdAsync(int id)
        {
            // Veritabanından doktoru ID'ye göre almak için Repository kullanılır.
            return await _adminrepository.GetByIdAsync(id);
        }

        public async Task<CommentEntity?> UpdateAsync(int id, CommentEntity entity)
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
