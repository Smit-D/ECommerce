using Services.AuthServices;

namespace ECommerce.Api.Extensions
{
    public static class ConfigServicesExt
    {
        #region AddAuthService
        public static IServiceCollection AddAuthServiceGroup(
          this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            return services;
        }
        #endregion 
    }
}
