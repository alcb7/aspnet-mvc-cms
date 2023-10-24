using Cms.Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Services.Abstract
{
    public interface IDoctorCategoryService : IDataRepository<DoctorCategoryEntity>
    {
        IQueryable<DoctorCategoryEntity> GetAll();
        Task<DoctorCategoryEntity?> GetByIdAsync(int id);
        Task<DoctorCategoryEntity> AddAsync(DoctorCategoryEntity entity);
        Task<DoctorCategoryEntity?> UpdateAsync(int id, DoctorCategoryEntity entity);
        Task<bool> DeleteAsync(int id);
    }
}
