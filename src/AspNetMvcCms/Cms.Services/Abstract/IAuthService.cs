using Cms.Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Services.Abstract
{
    public interface IAuthService 
    {
        Task<bool> AuthenticateAsync(string username, string password);
       
    }
}
