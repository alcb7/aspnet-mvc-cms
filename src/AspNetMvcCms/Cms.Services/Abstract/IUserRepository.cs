using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Services.Abstract
{
    public interface IUserRepository<TEntity>
    {
        Task<TEntity> GetUserByUsername(string username);
    }
}
