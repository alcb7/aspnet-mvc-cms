using Cms.Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Services.Abstract
{
	public interface IPatientCommentService : IDataRepository<PatientCommentEntity>
	{
		IQueryable<PatientCommentEntity> GetAll();
		Task<PatientCommentEntity?> GetByIdAsync(int id);
		Task<PatientCommentEntity> AddAsync(PatientCommentEntity entity);
		Task<PatientCommentEntity?> UpdateAsync(int id, PatientCommentEntity entity);
		Task<bool> DeleteAsync(int id);
	}
}
