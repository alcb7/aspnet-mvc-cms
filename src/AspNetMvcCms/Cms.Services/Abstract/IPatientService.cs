using Cms.Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Services.Abstract
{
    public interface IPatientService : IDataRepository<PatientEntity>
    {
        IQueryable<PatientEntity> GetAll();
        Task<PatientEntity?> GetByIdAsync(int id);
        Task<PatientEntity> AddAsync(PatientEntity entity);
        Task<PatientEntity?> UpdateAsync(int id, PatientEntity entity);
        Task<bool> DeleteAsync(int id);
    }
}
