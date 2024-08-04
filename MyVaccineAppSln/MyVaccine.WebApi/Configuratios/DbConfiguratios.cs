using Microsoft.EntityFrameworkCore;
using MyVaccine.WebApi.Literals;
using MyVaccine.WebApi.Models;

namespace MyVaccine.WebApi.Configuratios
{
    public static class DbConfiguratios
    {
        public static IServiceCollection SetDatabaseConfiguration(this IServiceCollection services)
        {
            var connectionstring = Environment.GetEnvironmentVariable(MyVaccineLiterals.CONNECTION_STRING);
            services.AddDbContext<MyVaccineAppDbContext>(options =>
                options.UseSqlServer(connectionstring));
            return services;
        }
    }
}

