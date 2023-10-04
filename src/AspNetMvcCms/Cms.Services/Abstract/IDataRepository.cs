using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Services.Abstract
{
    public interface IDataRepository<TEntity>
    {
        IQueryable<TEntity> GetAll();
        Task<TEntity?> GetByIdAsync(int id);
        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity?> UpdateAsync(int id, TEntity entity);
        Task<bool> DeleteAsync(int id);
    }
}
