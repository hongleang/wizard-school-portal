using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolPortalAPI.Entities;

namespace SchoolPortalAPI.Data.Configuration
{
    public class HouseConfiguration : IEntityTypeConfiguration<House>
    {
        public void Configure(EntityTypeBuilder<House> builder)
        {
            HouseSeeding(builder);
        }

        private void HouseSeeding(EntityTypeBuilder<House> builder)
        {

            // Seeding Initial data
            builder.HasData(
                new House()
                {
                    Id = 1,
                    Name = "Gryffindor",
                    Value = "bravery, daring, nerve, and chivalry",
                    Motto = "You might belong in Gryffindor,\r\nWhere dwell the brave at heart,\r\nTheir daring, nerve and chivalry\r\nSet Gryffindors apart.",
                    LogoUrl = "https://static.wikia.nocookie.net/harrypotter/images/9/98/Gryffindor.jpg/revision/latest?cb=20110503103732",
                    FounderId = 1,
                },
                new House()
                {
                    Id = 2,
                    Name = "Hufflepuff",
                    Value = "hard work, dedication, patience, loyalty, and fair play",
                    Motto = "You might belong in Hufflepuff\r\nWhere they are just and loyal\r\nThose patient Hufflepuffs are true\r\nAnd unafraid of toil",
                    LogoUrl = "https://static.wikia.nocookie.net/harrypotter/images/0/06/Hufflepuff_ClearBG.png/revision/latest?cb=20161020182518",
                    FounderId = 2,
                },
                new House()
                {
                    Id = 3,
                    Name = "Ravenclaw",
                    Value = "intelligence, knowledge, curiosity, creativity and wit",
                    Motto = "Or yet in wise old Ravenclaw\r\nIf you’ve a ready mind\r\nWhere those of wit and learning\r\nWill always find their kind",
                    LogoUrl = "https://static.wikia.nocookie.net/harrypotter/images/7/71/Ravenclaw_ClearBG.png/revision/latest?cb=20161020182442",
                    FounderId = 3,
                },
                new House()
                {
                    Id = 4,
                    Name = "Slytherin",
                    Value = "ambition, leadership, self-preservation, cunning and resourcefulness",
                    Motto = "Or perhaps in Slytherin\r\nYou’ll make your real friends\r\nThose cunning folk use any means\r\nTo achieve their ends",
                    LogoUrl = "https://static.wikia.nocookie.net/harrypotter/images/0/00/Slytherin_ClearBG.png/revision/latest?cb=20161020182557",
                    FounderId = 4,
                }
            );
        }
    }
}
