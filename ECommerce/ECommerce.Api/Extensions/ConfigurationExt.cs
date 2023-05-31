using Common.AppSettings;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using Services.AuthServices;

namespace ECommerce.Api.Extensions
{
    public static class ConfigurationExt
    {
        #region Add AppSettings Configurations
        public static IServiceCollection AddAppSettingsConfig(this IServiceCollection services,IConfiguration configuration)
        {
            services.Configure<SecretKeys>(configuration.GetSection("SecretKeys"));
            services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
            return services;
        }
        #endregion

        #region Add DbContext Configurations
        public static IServiceCollection AddDbConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ECommerceDBContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            return services;
        }
        #endregion

    }
}
