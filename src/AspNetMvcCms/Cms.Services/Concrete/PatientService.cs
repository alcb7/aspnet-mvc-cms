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
    public class PatientService : IPatientService
    {
        private readonly IDataRepository<PatientEntity> _patientrepository;
        private readonly AppDbContext _appDbContext;
        public PatientService(IDataRepository<PatientEntity> patientrepository, AppDbContext appDbContext)
        {
            _patientrepository = patientrepository;
            _appDbContext = appDbContext;
        }

        public async Task<PatientEntity> AddAsync(PatientEntity entity)
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

        public IQueryable<PatientEntity> GetAll()
        {
            // Tüm doktorları almak için Repository kullanılır.
            return _patientrepository.GetAll();
            //return _appDbContext.Doctors
            //    .Include(d => d.Category);


        }

        public async Task<PatientEntity?> GetByIdAsync(int id)
        {
            // Veritabanından doktoru ID'ye göre almak için Repository kullanılır.
            return await _patientrepository.GetByIdAsync(id);
        }

        public async Task<PatientEntity?> UpdateAsync(int id, PatientEntity entity)
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
