using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Trip_Management_Contracts;
using Trip_Management_Entities;
using Trip_Management_Repository;
using TripManagement_LoggerService;

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

        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
           services.AddScoped<IRepositoryManager, RepositoryManager>();

        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Trip_Management_Api", Version = "v1" });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Place to add JWT with bearer",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Name = "Bearer",
                        },
                        new List<string>()
                    }
                });
            });
        }

        public static void ConfigureLoggerService(this IServiceCollection services) =>
           services.AddScoped<ILoggerManager, LoggerManager>();
    }
}
