using Cms.Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Services.Abstract
{
    public interface IAppointmentService : IDataRepository<AppointmentEntity>
    {
        IQueryable<AppointmentEntity> GetAll();
        Task<AppointmentEntity?> GetByIdAsync(int id);
        Task<AppointmentEntity> AddAsync(AppointmentEntity entity);
        Task<AppointmentEntity?> UpdateAsync(int id, AppointmentEntity entity);
        Task<bool> DeleteAsync(int id);
		IQueryable<AppointmentEntity> GetByDoctorId(int doctorId);
	}
}
