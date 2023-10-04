using Cms.Shared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Services.Abstract
{
    public interface IApiService
    {
        Task<IServiceResult<TModel>> GetAsync<TModel>(string url, CancellationToken cancellationToken);
        Task<IServiceResult<TModel>> PostAsync<TModel>(string url, TModel data, CancellationToken cancellationToken);
        Task<IServiceResult<TModel>> PutAsync<TModel>(string url, TModel data, CancellationToken cancellationToken);
        Task<IServiceResult> DeleteAsync(string url, CancellationToken cancellationToken);
    }
}
