using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trip_Management_Entities.Models;

namespace Trip_Management_Entities.Configuration
{
    public class TripCustomerConfiguration : IEntityTypeConfiguration<TripCustomer>
    {
        public void Configure(EntityTypeBuilder<TripCustomer> builder)
        {
            builder.HasKey(s => new { s.CustomerId,s.TripId });

            builder.HasOne(s => s.Trip)
                .WithMany(s => s.TripCustomers)
                .HasForeignKey(s => s.TripId);

            builder.HasOne(ss => ss.Customer)
                .WithMany(ss => ss.TripCustomers)
                .HasForeignKey(ss => ss.CustomerId);

        }
    }
}
