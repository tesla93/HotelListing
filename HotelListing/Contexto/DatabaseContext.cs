using HotelListing.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace HotelListing.Contexto
{
	public class DatabaseContext : IdentityDbContext<ApiUser>
	{
        public DatabaseContext(DbContextOptions options): base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Country>().HasData(
                new Country
                {
                    Id = 1,
                    Name = "Cuba",
                    ShortName = "CU"
                },
                new Country
                {
                    Id = 2,
                    Name = "Canada",
                    ShortName = "CA"
                },
                new Country
                {
                    Id = 3,
                    Name = "Portugal",
                    ShortName = "PT"
                }
                );
            builder.Entity<Hotel>().HasData(
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
                ) ;
        }

        public DbSet<Country> Countries{ get; set; }
        public DbSet<Hotel> Hotels{ get; set; }
    }
}

