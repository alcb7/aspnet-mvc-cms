using Cms.Data.Context;
using Cms.Data.Models.Entities;
using Cms.Services.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Cms.Services.Concrete
{
    public class DoctorService : IDoctorService
    {
        private readonly IDataRepository<DoctorEntity> _repository;
        private readonly AppDbContext _appDbContext;
        public DoctorService(IDataRepository<DoctorEntity> repository, AppDbContext appDbContext)
        {
            _repository = repository;
            _appDbContext = appDbContext;
        }

        public async Task<DoctorEntity> AddAsync(DoctorEntity entity)
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

        public IQueryable<DoctorEntity> GetAll()
        {
            // Tüm doktorları almak için Repository kullanılır.
            //return _repository.GetAll();
            return _appDbContext.Doctors
                .Include(d => d.Category);


        }

        public async Task<DoctorEntity?> GetByIdAsync(int id)
        {
            // Veritabanından doktoru ID'ye göre almak için Repository kullanılır.
            return await _repository.GetByIdAsync(id);
        }

        public async Task<DoctorEntity?> UpdateAsync(int id, DoctorEntity entity)
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
