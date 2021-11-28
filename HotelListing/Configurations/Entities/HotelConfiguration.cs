using HotelListing.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelListing.Configurations.Entities
{
    public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.HasData(
                new Hotel
                {
                    Id = 1,
                    Name = "Varadero",
                    Address = "Matanzas",
                    Rating = 3.56,
                    CountryId = 1
                },
                new Hotel
                {
                    Id = 2,
                    Name = "Mont le Blanc",
                    Address = "Montreal",
                    Rating = 4.59,
                    CountryId = 2
                },
                 new Hotel
                 {
                     Id = 3,
                     Name = "Traviatta",
                     Address = "Porto",
                     Rating = 4.19,
                     CountryId = 3
                 }
                );
        }
    }
}
