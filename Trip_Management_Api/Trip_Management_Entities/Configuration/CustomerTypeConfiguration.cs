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
    public class CustomerTypeConfiguration : IEntityTypeConfiguration<CustomerType>
    {
        public void Configure(EntityTypeBuilder<CustomerType> builder)
        {
            builder.HasData(
                  new CustomerType
                  {
                      CustomerTypeId = 1,
                      CustomerTypeName = "Adults"
                  },
                  new CustomerType
                  {
                      CustomerTypeId = 2,
                      CustomerTypeName = "Children"
                  },
                  new CustomerType
                  {
                      CustomerTypeId = 3,
                      CustomerTypeName = "Infant"
                  }
                );
        }
    }
}
