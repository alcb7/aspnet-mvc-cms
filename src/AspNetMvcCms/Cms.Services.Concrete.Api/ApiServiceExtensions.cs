using Cms.Data.Models.Entities;
using Cms.Services.Abstract;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Services.Concrete.Api
{
    public static class ApiServiceExtensions
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services, string connectionString)
        {
            services.AddCmsDbContext(connectionString);
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IDataRepository<UserEntity>, DataRepository<UserEntity>>();
            return services;
        }
    }
}
