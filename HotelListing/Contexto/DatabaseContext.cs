﻿using HotelListing.Configurations.Entities;
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
            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new CountryConfiguration());
            builder.ApplyConfiguration(new HotelConfiguration());

        }

        public DbSet<Country> Countries{ get; set; }
        public DbSet<Hotel> Hotels{ get; set; }
    }
}

