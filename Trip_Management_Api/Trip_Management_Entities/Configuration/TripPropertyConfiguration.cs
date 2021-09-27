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
    public class TripPropertyConfiguration : IEntityTypeConfiguration<TripProperty>
    {
        public void Configure(EntityTypeBuilder<TripProperty> builder)
        {
            builder.HasData(            
                    new TripProperty
                    {
                        TripPropertyId = 1,
                        TripPropertyType = "Hotels"
                    },
                    new TripProperty
                    {
                        TripPropertyId = 2,
                        TripPropertyType = "House"
                    },
                    new TripProperty
                    {
                        TripPropertyId = 3,
                        TripPropertyType = "Apartment"
                    },
                    new TripProperty
                    {
                        TripPropertyId = 4,
                        TripPropertyType = "Hostel"
                    },
                    new TripProperty
                    {
                        TripPropertyId = 5,
                        TripPropertyType = "Resort"
                    },
                    new TripProperty
                    {
                        TripPropertyId = 6,
                        TripPropertyType = "Villa"
                    }

                );
        }
    }
}
