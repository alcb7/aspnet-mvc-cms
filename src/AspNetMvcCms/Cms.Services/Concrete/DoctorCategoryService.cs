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
    public class DoctorCategoryService : IDoctorCategoryService
    {
        private readonly IDataRepository<DoctorCategoryEntity> _patientrepository;
        private readonly AppDbContext _appDbContext;

        public DoctorCategoryService(IDataRepository<DoctorCategoryEntity> patientrepository, AppDbContext appDbContext)
        {
            _patientrepository = patientrepository;
            _appDbContext = appDbContext;
        }

        public async Task<DoctorCategoryEntity> AddAsync(DoctorCategoryEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            // Veritabanına yeni bir doktor eklemek için Repository kullanılır.
            return await _patientrepository.AddAsync(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            // Veritabanından doktoru ID'ye göre silmek için Repository kullanılır.
            return await _patientrepository.DeleteAsync(id);
        }

        public IQueryable<DoctorCategoryEntity> GetAll()
        {
            // Tüm doktorları almak için Repository kullanılır.
            //return _patientrepository.GetAll();
            return _appDbContext.DoctorCategories
                .Include(d => d.Doctors);


        }

        public IQueryable<DoctorCategoryEntity> GetByDoctorCategoryId(int dcategoryid)
        {
            return _patientrepository.GetAll()
       .Where(a => a.. == dcategoryid)
      .Include(d => d.Doctor);


        }

        public async Task<DoctorCategoryEntity?> GetByIdAsync(int id)
        {
            // Veritabanından doktoru ID'ye göre almak için Repository kullanılır.
            return await _patientrepository.GetByIdAsync(id);
        }

        public async Task<DoctorCategoryEntity?> UpdateAsync(int id, DoctorCategoryEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            // Veritabanında doktoru güncellemek için Repository kullanılır.
            return await _patientrepository.UpdateAsync(id, entity);
        }
    }
}
