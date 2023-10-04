using Cms.Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Services.Abstract
{
    public interface IDoctorService
    {
        IQueryable<DoctorEntity> GetAll();
        Task<DoctorEntity?> GetByIdAsync(int id);
        Task<DoctorEntity> AddAsync(DoctorEntity entity);
        Task<DoctorEntity?> UpdateAsync(int id, DoctorEntity entity);
        Task<bool> DeleteAsync(int id);
    }
}
