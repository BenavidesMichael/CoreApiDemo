﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CoreApiDemo.Infrastructure
{
    public static class AppSettingsExtentions
    {
        public static IServiceCollection GetAppSettingsValues(this IServiceCollection services, IConfiguration configuration)
        {
            //services.Configure<PaginationSetting>(opt => configuration.GetSection("Pagination").Bind(opt));
            return services;
        }
    }
}
