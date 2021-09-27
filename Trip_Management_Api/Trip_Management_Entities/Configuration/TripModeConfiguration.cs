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
    public class TripModeConfiguration : IEntityTypeConfiguration<TripMode>
    {
        public void Configure(EntityTypeBuilder<TripMode> builder)
        {
            builder.HasData
                (
                   new TripMode
                   {
                       TripModeId = 1,
                       TripModeType = "Flights"
                   },
                   new TripMode
                   {
                       TripModeId = 2,
                       TripModeType = "Trains"
                   },
                   new TripMode
                   {
                       TripModeId = 3,
                       TripModeType = "Cruises"
                   },
                   new TripMode
                   {
                       TripModeId = 4,
                       TripModeType = "Rental Cars"
                   },
                   new TripMode
                   {
                       TripModeId = 5,
                       TripModeType = "Road Trips"
                   }
                );
        }
    }
}
