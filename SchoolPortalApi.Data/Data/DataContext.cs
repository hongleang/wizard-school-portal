using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchoolPortalApi.Data.Data.Configuration;
using SchoolPortalApi.Data.Entities;
using SchoolPortalAPI.Data.Configuration;
using SchoolPortalAPI.Entities;

namespace SchoolPortalAPI.Data
{
    public class DataContext : IdentityDbContext<User>
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
            modelBuilder.ApplyConfiguration(new CharactersConfiguration());
            modelBuilder.ApplyConfiguration(new HouseConfiguration());
            modelBuilder.ApplyConfiguration(new FoundersConfiguration());
            modelBuilder.ApplyConfiguration(new RolesConfiguration());
        }
        public DbSet<Founder> Founders { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<House> Houses { get; set; }
    }
}
