using Cms.Services.Models.Auth;
using Cms.Shared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Services.Abstract
{
    public interface IAuthService
    {
        Task<IServiceResult<TokenResponseModel>> LoginAsync(string username, string password, CancellationToken cancellationToken);
    }
}
