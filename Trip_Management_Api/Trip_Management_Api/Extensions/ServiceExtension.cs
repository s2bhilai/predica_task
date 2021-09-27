using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trip_Management_Entities;

namespace Trip_Management_Api.Extensions
{
    public static class ServiceExtension
    {
        public static void ConfigureSqlContext(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<TripContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("DbConnection"),
                         m => m.MigrationsAssembly("Trip_Management_Api"))
            );
        }

        public static void ConfigureCountryLayerHttpClient(this IServiceCollection services,
            IConfiguration configuration)
        {
            var apiSettings = configuration.GetSection("CountryLayer_API_Info");

            services.AddHttpClient("countryLayerApi", client =>
             {
                 client.BaseAddress = new Uri(apiSettings.GetSection("ApiUrl").Value);
             });
        }
    }
}
