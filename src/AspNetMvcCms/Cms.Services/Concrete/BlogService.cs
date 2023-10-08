﻿using Cms.Data.Context;
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
    public class BlogService : IBlogService
    {
        private readonly IDataRepository<BlogEntity> _blogrepository;
        private readonly AppDbContext _appDbContext;
        public BlogService(IDataRepository<BlogEntity> blogrepository, AppDbContext appDbContext)
        {
            _blogrepository = blogrepository;
            _appDbContext = appDbContext;
        }

        public async Task<BlogEntity> AddAsync(BlogEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            // Veritabanına yeni bir doktor eklemek için Repository kullanılır.
            return await _blogrepository.AddAsync(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            // Veritabanından doktoru ID'ye göre silmek için Repository kullanılır.
            return await _blogrepository.DeleteAsync(id);
        }

        public IQueryable<BlogEntity> GetAll()
        {
            // Tüm doktorları almak için Repository kullanılır.
            //return _blogrepository.GetAll();
            return _appDbContext.Blogs
                .Include(d => d.Category);


        }

        public async Task<BlogEntity?> GetByIdAsync(int id)
        {
            // Veritabanından doktoru ID'ye göre almak için Repository kullanılır.
            return await _blogrepository.GetByIdAsync(id);
        }

        public async Task<BlogEntity?> UpdateAsync(int id, BlogEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            // Veritabanında doktoru güncellemek için Repository kullanılır.
            return await _blogrepository.UpdateAsync(id, entity);
        }
    }
}
