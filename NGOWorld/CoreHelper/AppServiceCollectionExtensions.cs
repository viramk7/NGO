using NGOWorld.Data.Repository.Doctor;
using NGOWorld.Data.Repository.Generic;
using NGOWorld.Service.DoctorService;
using NGOWorld.Service.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class AppServiceCollectionExtensions
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services)
        {
            // Infrastructure
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            //// Repositories
            services.AddTransient<IDoctorRepository, DoctorRepository>();

            //// Services
            services.AddScoped(typeof(IEntityService<>), typeof(EntityService<>));
            services.AddTransient<IDoctorService, DoctorService>();

            return services;
        }
    }
}
