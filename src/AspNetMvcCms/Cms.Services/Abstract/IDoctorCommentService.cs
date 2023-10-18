using Cms.Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Services.Abstract
{
    public interface IDoctorCommentService : IDataRepository<DoctorCommentEntity>
    {
        IQueryable<DoctorCommentEntity> GetAll();
        Task<DoctorCommentEntity?> GetByIdAsync(int id);
        Task<DoctorCommentEntity> AddAsync(DoctorCommentEntity entity);
        Task<DoctorCommentEntity?> UpdateAsync(int id, DoctorCommentEntity entity);
        Task<bool> DeleteAsync(int id);
    }
}
