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
	public class PatientCommentService : IPatientCommentService
	{
		private readonly IDataRepository<PatientCommentEntity> _repository;
		private readonly AppDbContext _appDbContext;
		public PatientCommentService(IDataRepository<PatientCommentEntity> repository, AppDbContext appDbContext)
		{
			_repository = repository;
			_appDbContext = appDbContext;
		}

		public async Task<PatientCommentEntity> AddAsync(PatientCommentEntity entity)
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

		public IQueryable<PatientCommentEntity> GetAll()
		{
			// Tüm doktorları almak için Repository kullanılır.
			//return _repository.GetAll();
			return _appDbContext.PatientComments
			   .Include(d => d.Patient);


		}

		public async Task<PatientCommentEntity?> GetByIdAsync(int id)
		{
			// Veritabanından doktoru ID'ye göre almak için Repository kullanılır.
			return await _repository.GetByIdAsync(id);
		}

		public async Task<PatientCommentEntity?> UpdateAsync(int id, PatientCommentEntity entity)
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
