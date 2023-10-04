using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Shared.Data
{
    public interface ICanDisable
    {
        bool IsDisabled { get; set; }
    }
}
