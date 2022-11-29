using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolPortalAPI.Entities;

namespace SchoolPortalAPI.Data.Configuration
{
    public class CharactersConfiguration : IEntityTypeConfiguration<Character>
    {
        public void Configure(EntityTypeBuilder<Character> builder)
        {
            CharacterSeeding(builder);
        }

        private void CharacterSeeding(EntityTypeBuilder<Character> builder)
        {
            // Seeding Initial data
            builder.HasData(
                new Character()
                {
                    Id = 1,
                    Name = "Harry Potter",
                    Gender = "male",
                    ImageUrl = "http://hp-api.herokuapp.com/images/harry.jpg,Gryffindor",
                    HouseId = 1
                },
                new Character()
                {
                    Id = 2,
                    Name = "Hermione Granger",
                    Gender = "female",
                    ImageUrl = "http://hp-api.herokuapp.com/images/hermione.jpeg,Gryffindor",
                    HouseId = 1
                }, new Character()
                {
                    Id = 3,
                    Name = "Ron Weasley",
                    Gender = "male",
                    ImageUrl = "http://hp-api.herokuapp.com/images/ron.jpg,Gryffindor",
                    HouseId = 1
                }, new Character()
                {
                    Id = 4,
                    Name = "Draco Malfoy",
                    Gender = "male",
                    ImageUrl = "http://hp-api.herokuapp.com/images/draco.jpg,Slytherin",
                    HouseId = 4
                }, new Character()
                {
                    Id = 5,
                    Name = "Bellatrix Lestrange",
                    Gender = "female",
                    ImageUrl = "http://hp-api.herokuapp.com/images/bellatrix.jpg,Slytherin",
                    HouseId = 4
                }, new Character()
                {
                    Id = 6,
                    Name = "Cho Chang",
                    Gender = "female",
                    ImageUrl = "http://hp-api.herokuapp.com/images/cho.jpg,Ravenclaw",
                    HouseId = 3
                }, new Character()
                {
                    Id = 7,
                    Name = "Luna Lovegood",
                    Gender = "female",
                    ImageUrl = "http://hp-api.herokuapp.com/images/luna.jpg,Ravenclaw",
                    HouseId = 3
                }, new Character()
                {
                    Id = 8,
                    Name = "Cedric Diggory",
                    Gender = "male",
                    ImageUrl = "http://hp-api.herokuapp.com/images/cedric.png,Hufflepuff",
                    HouseId = 2
                }, new Character()
                {
                    Id = 9,
                    Name = "Nymphadora Tonks",
                    Gender = "female",
                    ImageUrl = "https://static.wikia.nocookie.net/harrypotter/images/c/c8/Nymphadora_Tonks_DH_promo_headshot_.jpg/revision/latest?cb=20161119222048,Hufflepuff",
                    HouseId = 2
                }
            );
        }
    }
}
