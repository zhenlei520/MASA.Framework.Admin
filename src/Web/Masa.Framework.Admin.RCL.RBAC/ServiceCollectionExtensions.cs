using Masa.Framework.Admin.RCL.RBAC;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRBAC(this IServiceCollection services)
        {
            services.AddScoped<MenuPage>();

            return services;
        }
    }
}
