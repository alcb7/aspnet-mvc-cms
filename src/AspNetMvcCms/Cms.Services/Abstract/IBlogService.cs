using Cms.Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Services.Abstract
{
    public interface IBlogService : IDataRepository<BlogEntity>
    {
        IQueryable<BlogEntity> GetAll();
        Task<BlogEntity?> GetByIdAsync(int id);
        Task<BlogEntity> AddAsync(BlogEntity entity);
        Task<BlogEntity?> UpdateAsync(int id, BlogEntity entity);
        Task<bool> DeleteAsync(int id);
	

	}
}
