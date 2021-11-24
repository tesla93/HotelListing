using HotelListing.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace HotelListing.Contexto
{
	public class DatabaseContext : DbContext
	{
        public DatabaseContext(DbContextOptions options): base(options)
        {
        }

        public DbSet<Country> Countries{ get; set; }
        public DbSet<Hotel> Hotels{ get; set; }
    }
}

