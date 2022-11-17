using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolPortalAPI.Entities;

namespace SchoolPortalAPI.Data.Configuration
{
    public class FoundersConfiguration : IEntityTypeConfiguration<Founder>
    {
        public void Configure(EntityTypeBuilder<Founder> builder)
        {
            // Seeding Initial data
            builder.HasData(
                new Founder()
                {
                    Id = 1,
                    Name = "Godric Gryffindor",
                    Gender = "male",
                    ImageUrl = "https://static.wikia.nocookie.net/harrypotter/images/3/31/Founders_gryffindor1.jpg/revision/latest?cb=20180611200439",
                    Quote = "We'll teach all those with brave deeds to their name."
                },
                new Founder()
                {
                    Id = 2,
                    Name = "Helga Hufflepuff",
                    Gender = "female",
                    ImageUrl = "https://static.wikia.nocookie.net/harrypotter/images/d/d7/Helga_Hufflepuff.jpg/revision/latest?cb=20140615154415",
                    Quote = "I'll teach the lot and treat them just the same."
                },
                new Founder()
                {
                    Id = 3,
                    Name = "Rowena Ravenclaw",
                    Gender = "female",
                    ImageUrl = "https://static.wikia.nocookie.net/harrypotter/images/f/fd/Rowena_Ravenclaw_at_WWHP.jpg/revision/latest?cb=20140615151812",
                    Quote = "Wit beyond measure is man's greatest treasure."
                },
                new Founder()
                {
                    Id = 4,
                    Name = "Salazar Slytherin",
                    Gender = "male",
                    ImageUrl = "https://static.wikia.nocookie.net/harrypotter/images/8/86/Salazar_Slytherin_WWHP.jpg/revision/latest?cb=20140615154545",
                    Quote = "We'll teach just those whose ancestry's purest."
                }
            );
        }
    }
}
