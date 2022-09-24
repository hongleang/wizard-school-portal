using API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Data.Configuration
{
    public class HouseConfiguration : IEntityTypeConfiguration<House>
    {
        public void Configure(EntityTypeBuilder<House> builder)
        {
            builder.Property(h => h.Name)
               .IsRequired()
               .HasColumnType("string")
               .HasMaxLength(10);

            builder.Property(h => h.Value)
                .IsRequired()
                .HasColumnType("string")
                .HasMaxLength(20);

            builder.Property(h => h.Motto)
                .IsRequired()
                .HasColumnType("string")
                .HasMaxLength(50);

            builder.Property(h => h.LogoUrl)
                .IsRequired()
                .HasColumnType("string");

            builder.HasMany(h => h.Users).WithOne(u => u.House);

            builder.HasOne(h => h.Founder).WithOne(h => h.House).HasForeignKey<Founder>(h => h.HouseId);

            builder.HasMany(h => h.NotableCharacters).WithOne(u => u.House);
        }
    }
}
