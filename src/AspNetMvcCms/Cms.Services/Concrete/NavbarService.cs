using Cms.Data.Context;
using Cms.Data.Models.Entities;
using Cms.Services.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Services.Concrete
{
    public class NavbarService : INavbarService
    {
        private readonly IDataRepository<NavbarEntity> _repository;
        private readonly AppDbContext _appDbContext;
        public NavbarService(IDataRepository<NavbarEntity> repository, AppDbContext appDbContext)
        {
            _repository = repository;
            _appDbContext = appDbContext;
        }

        public async Task<NavbarEntity> AddAsync(NavbarEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            // Veritabanına yeni bir doktor eklemek için Repository kullanılır.
            return await _repository.AddAsync(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            // Veritabanından doktoru ID'ye göre silmek için Repository kullanılır.
            return await _repository.DeleteAsync(id);
        }

        public IQueryable<NavbarEntity> GetAll()
        {
            // Tüm doktorları almak için Repository kullanılır.
            //return _repository.GetAll();
            return _appDbContext.Navbars
                .Include(d => d.Doctors);


        }

        public async Task<NavbarEntity?> GetByIdAsync(int id)
        {
            // Veritabanından doktoru ID'ye göre almak için Repository kullanılır.
            return await _repository.GetByIdAsync(id);
        }

        public async Task<NavbarEntity?> UpdateAsync(int id, NavbarEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            // Veritabanında doktoru güncellemek için Repository kullanılır.
            return await _repository.UpdateAsync(id, entity);
        }
    }
}
