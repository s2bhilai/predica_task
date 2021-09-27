using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trip_Management_Entities;
using Trip_Management_Entities.Entities;
using Trip_Management_Entities.Models;

namespace Trip_Management_Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                try
                {
                    var tripcontext = scope.ServiceProvider.GetService<TripContext>();
                    //context.Database.EnsureDeleted();
                    tripcontext.Database.EnsureCreated();

                    var seeder = scope.ServiceProvider.GetService<CountryLayerDataSeeder>();
                    List<CountryLayer> countryLayerDetails =  seeder.SeedCountryData().GetAwaiter().GetResult();

                    if (!tripcontext.TripSpots.Any())
                    {
                        List<TripSpot> tripSpots = new List<TripSpot>();

                        foreach (CountryLayer cl in countryLayerDetails)
                        {
                            tripSpots.Add(new TripSpot()
                            {
                                CountryName = cl.Name,
                                Region = cl.Region,
                                Capital = cl.Capital
                            });
                        }

                        tripcontext.TripSpots.AddRange(tripSpots);
                        tripcontext.SaveChanges();
                    }
                }
                catch(Exception ex)
                {

                }
            }


            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
