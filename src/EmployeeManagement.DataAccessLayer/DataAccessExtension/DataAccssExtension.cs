using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EmpMgmt.DataAccess.DataAccessExtension
{
    public static class DataAccssExtension
    {
        public static IServiceCollection AddDataAccessExtension(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EmployeeManagementContext>(option =>
            {
                option.UseSqlServer(
                        configuration.GetConnectionString("DefaultConnection"),
                        option => option.EnableRetryOnFailure(5, TimeSpan.FromSeconds(30), null)
                    );
            });

            return services;
        }
    }
}
