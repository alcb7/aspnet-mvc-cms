﻿using Cms.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Data
{
    public static class DataExtensions
    {
        public static void AddCmsDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<DbContext, AppDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
        }
    }
}