using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trip_Management_Entities.Configuration;
using Trip_Management_Entities.Models;

namespace Trip_Management_Entities
{
    public class TripContext: DbContext
    {
        public TripContext(DbContextOptions<TripContext> options)
            :base(options)
        {

        }

        public DbSet<Trip> Trips { get; set; }
        public DbSet<Customer> Customers { get; set; }    
        public DbSet<TripSpot> TripSpots { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerTypeConfiguration());
            modelBuilder.ApplyConfiguration(new TripModeConfiguration());
            modelBuilder.ApplyConfiguration(new TripPropertyConfiguration());
            modelBuilder.ApplyConfiguration(new TripTypeConfiguration());
            modelBuilder.ApplyConfiguration(new TripCustomerConfiguration());
        }
    }
}
