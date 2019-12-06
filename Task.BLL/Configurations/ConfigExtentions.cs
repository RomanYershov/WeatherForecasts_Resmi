using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Task.BLL.Abstracrions;
using Task.BLL.Services;

namespace Task.BLL.Configurations
{
    public static class ConfigExtentions
    {
        public static void RegisterTypes(this IServiceCollection services)
        {
            services.AddScoped<IForecastService, ForecastService>();
        }
    }
}
