using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// web扩展类
    /// </summary>
    public static class WebExtension
    {
        public static IServiceCollection AddWkMvcDI(this IServiceCollection services)
        {
            DI.Services = services;
            return services;
        }

        public static IApplicationBuilder UseWkMvcDI(this IApplicationBuilder builder)
        {
            DI.ServiceProvider = builder.ApplicationServices;
            return builder;
        }
    }

    public static class DI
    {
        public static IServiceProvider ServiceProvider { get; internal set; }

        public static IServiceCollection Services { get; internal set; }

        private static IConfiguration _configuration;
        public static IConfiguration Configuration { get { return _configuration; } }

        public static void SetConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;
        }
    }
}
