﻿using Cms.Services.Abstract;
using Cms.Shared.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Services.Concrete.Api
{
    internal class DataRepository<TEntity> : IDataRepository<TEntity> where TEntity : class, IAuditableEntity<int>, ICanDisable
    {
        private readonly DbContext _dbContext;

        public DataRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private DbSet<TEntity> Set => _dbContext.Set<TEntity>();

        private IQueryable<TEntity> GetAll(bool includeDisabled) => Set.AsNoTracking().Where(e => !includeDisabled || !e.IsDisabled);

        public async Task<TEntity> AddAsync(TEntity entity, int userId)
        {
            entity.IsDisabled = false;
            entity.Id = default;
            entity.CreatedDate = DateTime.UtcNow;
            entity.CreatedBy = userId;
            entity.LastModifiedDate = null;
            entity.LastModifiedBy = default;

            Set.Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity == null)
            {
                return false;
            }

            Set.Remove(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public IQueryable<TEntity> GetAll() => GetAll(true);

        public async Task<TEntity?> GetByIdAsync(int id)
        {
            return await GetAll(true).SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<TEntity?> UpdateAsync(int id, TEntity entity, int userId)
        {
            var dbEntity = await GetByIdAsync(id);
            if (dbEntity == null)
            {
                return null;
            }

            entity.Id = id;
            entity.IsDisabled = dbEntity.IsDisabled;
            entity.LastModifiedDate = DateTime.UtcNow;
            entity.LastModifiedBy = userId;

            Set.Update(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        
    }
}
