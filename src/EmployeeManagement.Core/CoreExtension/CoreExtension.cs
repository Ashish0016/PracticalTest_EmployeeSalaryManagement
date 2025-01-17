using EmpMgmt.DataAccess.DataAccessExtension;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EmpMgmt.Core.CoreExtension
{
    public static class CoreExtension
    {
        public static IServiceCollection AddCoreExtension(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDataAccessExtension(configuration);

            return services;
        }
    }
}
