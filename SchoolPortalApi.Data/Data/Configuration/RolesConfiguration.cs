using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolPortalApi.Data.Entities;

namespace SchoolPortalApi.Data.Data.Configuration
{
    public class RolesConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public RolesConfiguration()
        {
        }
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            SeedingRoles(builder);
        }
        private void SeedingRoles(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole()
                {
                    Name = "admin",
                    NormalizedName = "ADMIN",
                },
                new IdentityRole()
                {
                    Name = "user",
                    NormalizedName = "USER",
                }
            );
        }

    }
}
