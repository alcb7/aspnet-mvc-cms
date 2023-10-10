using Cms.Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Services.Abstract
{
    public interface IAppointmentService  
    {
        IQueryable AppointmentGetAll();
        Task AppointmentGetByIdAsync(int id);
        Task AppointmentAddAsync(AppointmentEntity entity);
        Task  AppointmentUpdateAsync(int id, AppointmentEntity entity);
        Task<bool> AppointmentDeleteAsync(int id);

    }
}
