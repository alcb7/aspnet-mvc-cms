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
        private readonly IAppointmentService _appointmentrepository;
        private readonly AppDbContext _appDbContext;

        public AppointmentService(IAppointmentService appointmentrepository, AppDbContext appDbContext)
        {
            _appointmentrepository = appointmentrepository;
            _appDbContext = appDbContext;
        }

        public  Task AppointmentAddAsync(AppointmentEntity entity)
            {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            // Veritabanına yeni bir doktor eklemek için Repository kullanılır.
            return    _appointmentrepository.AppointmentAddAsync(entity);
        }

        public Task<bool> AppointmentDeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable AppointmentGetAll()
            {
            return _appDbContext.Appointments
                    .Include(d => d.Patient)
                    .Include(d => d.Doctor);
            }

            public Task AppointmentGetByIdAsync(int id)
            {
                throw new NotImplementedException();
            }

            public Task AppointmentUpdateAsync(int id, AppointmentEntity entity)
            {
                throw new NotImplementedException();
            }
        }
    
}
