using API.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Founder> Founders { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<House> Houses { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
