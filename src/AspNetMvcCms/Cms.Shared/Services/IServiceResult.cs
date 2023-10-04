using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Shared.Services
{
    public interface IServiceResult
    {
        bool IsSuccess { get; set; }
        string Message { get; set; }
        int StatusCode { get; set; }
    }

    public interface IServiceResult<T> : IServiceResult
    {
        T? Data { get; set; }
    }
}
