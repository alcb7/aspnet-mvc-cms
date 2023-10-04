using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cms.Shared.Data;

namespace Cms.Services.Abstract
{
    public interface IDataRepository<TEntity> where TEntity : class, IEntity<int>
    {
        IQueryable<TEntity> GetAll();
        Task<TEntity?> GetByIdAsync(int id);
        Task<TEntity> AddAsync(TEntity entity, int userId);
        Task<TEntity?> UpdateAsync(int id, TEntity entity, int userId);
        Task<bool> DeleteAsync(int id);
    }
}
