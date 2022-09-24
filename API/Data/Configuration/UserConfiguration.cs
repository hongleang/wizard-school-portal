using API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Data.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.FirstName)
                .IsRequired()
                .HasColumnType("string")
                .HasMaxLength(15);

            builder.Property(u => u.LastName)
                .IsRequired()
                .HasColumnType("string")
                .HasMaxLength(15);

            builder.Property(u => u.Username)
                .IsRequired()
                .HasColumnType("string")
                .HasMaxLength(15);

            builder.Property(u => u.Species)
                .IsRequired()
                .HasColumnType("string")
                .HasMaxLength(15);

            builder.Property(u => u.DateOfBirth)
                .IsRequired()
                .HasColumnType("DateOnly");


            builder.HasOne(u => u.House).WithMany(u => u.Users);
        }
    }
}
