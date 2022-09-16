using API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Data.Configuration
{
    public class FounderConfiguration : IEntityTypeConfiguration<Founder>
    {
        public void Configure(EntityTypeBuilder<Founder> builder)
        {
            builder.Property(u => u.Name)
                .IsRequired()
                .HasColumnType("string")
                .HasMaxLength(15);

            builder.Property(u => u.Species)
                .IsRequired()
                .HasColumnType("string")
                .HasMaxLength(15);

            builder.Property(u => u.Ancestry)
                .IsRequired()
                .HasColumnType("string")
                .HasMaxLength(15);

            builder.Property(u => u.ImageUrl)
                .IsRequired()
                .HasColumnType("string");


            builder.HasOne(u => u.House).WithOne(u => u.Founder).HasForeignKey<House>(b => b.FounderId);
        }
    }
}
