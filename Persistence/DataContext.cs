﻿using System;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }
        // This will create a table calle "Values"
        public DbSet<Value> Values { get; set; }
        public DbSet<Activity> Activities { get; set; }
        
        // Override exisiting method inside DbContect Class.
        protected override void OnModelCreating(ModelBuilder builder)
        {
            // this will seed the Values table with data upon migration.
            builder.Entity<Value>()
                .HasData(
                    new Value {Id = 1, Name = "Value 101"},
                    new Value {Id = 2, Name = "Value 102"},
                    new Value {Id = 3, Name = "Value 103"},
                    new Value {Id = 4, Name = "Value 104"}
                );
        }
    }
}
