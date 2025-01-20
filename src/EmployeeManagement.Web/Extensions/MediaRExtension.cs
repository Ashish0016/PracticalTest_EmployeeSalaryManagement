using EmpMgmt.Core.Features.AddOrUpdateEmployeeFeature;

namespace EmpMgmt.Web.Extensions
{
    public static class MediaRExtension
    {
        public static IServiceCollection AddMediatR(this IServiceCollection services)
        {
            services.AddMediatR(option =>
            {
                option.RegisterServicesFromAssembly(typeof(AddOrUpdateEmployeeHandler).Assembly);
            });

            return services;
        }
    }
}
