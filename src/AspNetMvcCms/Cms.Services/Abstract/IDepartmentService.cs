using Cms.Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Services.Abstract
{
	public interface IDepartmentService : IDataRepository<DepartmentEntity>
	{
		IQueryable<DepartmentEntity> GetAll();
		Task<DepartmentEntity?> GetByIdAsync(int id);
		Task<DepartmentEntity> AddAsync(DepartmentEntity entity);
		Task<DepartmentEntity?> UpdateAsync(int id, DepartmentEntity entity);
		Task<bool> DeleteAsync(int id);
	}
}
