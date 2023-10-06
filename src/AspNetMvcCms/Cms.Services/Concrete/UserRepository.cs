using Cms.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Services.Concrete
{
    public class UserRepository<TEntity> : IUserRepository<TEntity> where TEntity : class, new()
    {
        public Task<TEntity> GetUserByUsername(string username)
        {
            throw new NotImplementedException();
        }
    }
}
