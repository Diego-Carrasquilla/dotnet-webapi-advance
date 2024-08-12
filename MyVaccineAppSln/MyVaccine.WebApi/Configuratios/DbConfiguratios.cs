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
            //var connectionstring = "Server=localhost;Database=MyVaccineAppDb;User Id=sa ;Password=Abc.123456;TrustServerCertificate=True;";
            services.AddDbContext<MyVaccineAppDbContext>(options =>
                options.UseSqlServer(connectionstring));
            return services;
        }
    }
}

