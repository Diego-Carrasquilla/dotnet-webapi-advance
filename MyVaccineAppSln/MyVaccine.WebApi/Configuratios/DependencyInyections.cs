using MyVaccine.WebApi.Repositories.Contracts;
using MyVaccine.WebApi.Repositories.Implementations;

namespace MyVaccine.WebApi.Configuratios
{
    public static class DependencyInyections
    {
        public static IServiceCollection SetDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }
    }
}
