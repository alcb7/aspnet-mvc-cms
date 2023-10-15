using Cms.Data.Context;
using Cms.Data.Models.Entities;
using Cms.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Services.Concrete
{
	public class DepartmentService : IDepartmentService
	{
		private readonly IDataRepository<DepartmentEntity> _repository;
		
		public DepartmentService(IDataRepository<DepartmentEntity> repository)
		{
			_repository = repository;
			
		}

		public async Task<DepartmentEntity> AddAsync(DepartmentEntity entity)
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

		public IQueryable<DepartmentEntity> GetAll()
		{
			// Tüm doktorları almak için Repository kullanılır.
			return _repository.GetAll();
			


		}

		public async Task<DepartmentEntity?> GetByIdAsync(int id)
		{
			// Veritabanından doktoru ID'ye göre almak için Repository kullanılır.
			return await _repository.GetByIdAsync(id);
		}

		public async Task<DepartmentEntity?> UpdateAsync(int id, DepartmentEntity entity)
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
