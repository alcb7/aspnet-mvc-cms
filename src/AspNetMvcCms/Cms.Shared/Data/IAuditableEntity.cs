using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Shared.Data
{
    public interface IAuditableEntity<T> : IEntity<T>
    {
        T CreatedBy { get; set; }
        DateTime CreatedDate { get; set; }
        T LastModifiedBy { get; set; }
        DateTime? LastModifiedDate { get; set; }
    }
}
