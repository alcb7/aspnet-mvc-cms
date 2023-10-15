using Cms.Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Services.Abstract
{
    public interface INavbarService : IDataRepository<NavbarEntity>
    {
        IQueryable<NavbarEntity> GetAll();
        Task<NavbarEntity?> GetByIdAsync(int id);
        Task<NavbarEntity> AddAsync(NavbarEntity entity);
        Task<NavbarEntity?> UpdateAsync(int id, NavbarEntity entity);
        Task<bool> DeleteAsync(int id);
    }
}
