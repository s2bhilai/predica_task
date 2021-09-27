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
    public class TripTypeConfiguration : IEntityTypeConfiguration<TripType>
    {
        public void Configure(EntityTypeBuilder<TripType> builder)
        {
            builder.HasData(
                  new TripType
                  {
                      TripTypeId = 1,
                      TripTypeDescription = "Family_Trip"
                  },
                  new TripType
                  {
                      TripTypeId = 2,
                      TripTypeDescription = "Trip_with_friends"
                  },
                  new TripType
                  {
                      TripTypeId = 3,
                      TripTypeDescription = "Solo_Trip"
                  },
                  new TripType
                  {
                      TripTypeId = 4,
                      TripTypeDescription = "Honeymoon_Trip"
                  },
                  new TripType
                  {
                      TripTypeId = 5,
                      TripTypeDescription = "Adventure"
                  },
                  new TripType
                  {
                      TripTypeId = 6,
                      TripTypeDescription = "Religious"
                  }
                );
        }
    }
}
