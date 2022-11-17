﻿using Microsoft.EntityFrameworkCore;
using SchoolPortalAPI.Data.Configuration;
using SchoolPortalAPI.Entities;
using System.Reflection;

namespace SchoolPortalAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new FoundersConfiguration());
            modelBuilder.ApplyConfiguration(new HouseConfiguration());
            modelBuilder.ApplyConfiguration(new CharactersConfiguration());
        }

        public DbSet<Founder> Founders { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<House> Houses { get; set; }
    }
}