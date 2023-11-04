using Cms.Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Services.Abstract
{
    public interface IBlogCategoriesService : IDataRepository<BlogCategoryEntity>
    {
        IQueryable<BlogCategoryEntity> GetAll();
        Task<BlogCategoryEntity?> GetByIdAsync(int id);
        Task<BlogCategoryEntity> AddAsync(BlogCategoryEntity entity);
        Task<BlogCategoryEntity?> UpdateAsync(int id, BlogCategoryEntity entity);
        Task<bool> DeleteAsync(int id);
    }
}
