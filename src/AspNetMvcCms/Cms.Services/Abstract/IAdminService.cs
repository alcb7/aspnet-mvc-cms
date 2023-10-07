using Cms.Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Services.Abstract
{
    public interface IAdminService : IDataRepository<AdminEntity>
    {
        IQueryable<AdminEntity> GetAll();
        Task<AdminEntity?> GetByIdAsync(int id);
        Task<AdminEntity> AddAsync(AdminEntity entity);
        Task<AdminEntity?> UpdateAsync(int id, AdminEntity entity);
        Task<bool> DeleteAsync(int id);
    }
}
