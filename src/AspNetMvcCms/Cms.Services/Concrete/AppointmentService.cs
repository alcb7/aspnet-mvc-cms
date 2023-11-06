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
    public class AppointmentService : IAppointmentService
    {
        private readonly IDataRepository<AppointmentEntity> _appointmentrepository;

        public AppointmentService(IDataRepository<AppointmentEntity> appointmentrepository)
        {
            _appointmentrepository = appointmentrepository;

        }

        public async Task<AppointmentEntity> AddAsync(AppointmentEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            // Veritabanına yeni bir doktor eklemek için Repository kullanılır.
            return await _appointmentrepository.AddAsync(entity);
            //.Include(d => d.Patient)
            //.Include(d => d.Doctor);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            // Veritabanından doktoru ID'ye göre silmek için Repository kullanılır.
            return await _appointmentrepository.DeleteAsync(id);
        }

        public IQueryable<AppointmentEntity> GetAll()
        {
            // Tüm doktorları almak için Repository kullanılır.
            //return _appointmentrepository.GetAll();
            return _appointmentrepository.GetAll()
                .Include(d => d.Patient)
                .Include(d => d.Doctor)
                .Include(d => d.Category);


        }


        public async Task<AppointmentEntity?> GetByDoctorId(int doctorId)
        {
            return await _appointmentrepository.GetAll()
       .Where(a => a.Doctor.Id == doctorId)
       .Include(d => d.Patient)
       .Include(d => d.Doctor)
       .Include(d => d.Category)
       .FirstOrDefaultAsync();
        }
        public async Task<AppointmentEntity?> GetByIdAsync(int id)
        {
            // Veritabanından doktoru ID'ye göre almak için Repository kullanılır.
            return await _appointmentrepository.GetByIdAsync(id);
        }

        public async Task<AppointmentEntity?> UpdateAsync(int id, AppointmentEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            // Veritabanında doktoru güncellemek için Repository kullanılır.
            return await _appointmentrepository.UpdateAsync(id, entity);
        }
    }
}