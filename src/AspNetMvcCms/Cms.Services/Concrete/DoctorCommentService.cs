using Cms.Data.Context;
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
    public class DoctorCommentService : IDoctorCommentService
    {
        private readonly IDataRepository<DoctorCommentEntity> _repository;
        private readonly AppDbContext _appDbContext;
        public DoctorCommentService(IDataRepository<DoctorCommentEntity> repository, AppDbContext appDbContext)
        {
            _repository = repository;
            _appDbContext = appDbContext;
        }

        public async Task<DoctorCommentEntity> AddAsync(DoctorCommentEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            // Veritabanına yeni bir doktor eklemek için Repository kullanılır.
            return await _repository.AddAsync(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            // Veritabanından doktoru ID'ye göre silmek için Repository kullanılır.
            return await _repository.DeleteAsync(id);
        }

        public IQueryable<DoctorCommentEntity> GetAll()
        {
            // Tüm doktorları almak için Repository kullanılır.
            //return _repository.GetAll();
            return _appDbContext.DoctorComments
               .Include(d => d.Doctor);


        }

		public IQueryable<DoctorCommentEntity> GetByDoctorId(int doctorId)
		{
			return _repository.GetAll()
	   .Where(a => a.Doctor.Id == doctorId)
	   
	   
	   ;
		}

		public async Task<DoctorCommentEntity?> GetByIdAsync(int id)
        {
            // Veritabanından doktoru ID'ye göre almak için Repository kullanılır.
            return await _repository.GetByIdAsync(id);
        }

        public async Task<DoctorCommentEntity?> UpdateAsync(int id, DoctorCommentEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            // Veritabanında doktoru güncellemek için Repository kullanılır.
            return await _repository.UpdateAsync(id, entity);
        }
    }
}
