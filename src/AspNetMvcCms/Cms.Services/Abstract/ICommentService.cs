using Cms.Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Services.Abstract
{
    public interface ICommentService : IDataRepository<CommentEntity>
    {
        IQueryable<CommentEntity> GetAll();
        Task<CommentEntity?> GetByIdAsync(int id);
        Task<CommentEntity> AddAsync(CommentEntity entity);
        Task<CommentEntity?> UpdateAsync(int id, CommentEntity entity);
        Task<bool> DeleteAsync(int id);
    }
}
