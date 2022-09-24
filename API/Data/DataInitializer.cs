using API.Entities;
using CsvHelper.Configuration;
using System.Globalization;

namespace API.Data
{
    public class DataInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var scope = applicationBuilder.ApplicationServices.CreateScope())
            {
                string root = Directory.GetCurrentDirectory() + "\\DataResources";
                string housesPath = root + "\\houses.csv";
                string charactersPath = root + "\\characters.csv";
                var csvConfig = new CsvConfiguration(CultureInfo.CurrentCulture)
                {
                    HasHeaderRecord = true,
                };

                // Get a list of houses and characters from Csv
                var houses = new DataProcessor(housesPath, csvConfig, "house").Houses;
                var characters = new DataProcessor(charactersPath, csvConfig, houses).Characters;

                var context = scope.ServiceProvider.GetService<DataContext>();

                if (!context.Founders.Any())
                {
                    context.AddRange(new Founder()
                    {
                        Name = "Godric Gryffindor",
                        Gender = "male",
                        Species = "human",
                        Ancestry = "pure-blood",
                        ImageUrl = "https://static.wikia.nocookie.net/harrypotter/images/3/31/Founders_gryffindor1.jpg/revision/latest?cb=20180611200439",
                        HouseId = 1
                    },
                    new Founder()
                    {
                        Name = "Helga Hufflepuff",
                        Gender = "fmale",
                        Species = "human",
                        Ancestry = "pure-blood",
                        ImageUrl = "https://static.wikia.nocookie.net/harrypotter/images/d/d7/Helga_Hufflepuff.jpg/revision/latest?cb=20140615154415",
                        HouseId = 2
                    },
                    new Founder()
                    {
                        Name = "Rowena Ravenclaw",
                        Gender = "female",
                        Species = "human",
                        Ancestry = "pure-blood",
                        ImageUrl = "https://static.wikia.nocookie.net/harrypotter/images/f/fd/Rowena_Ravenclaw_at_WWHP.jpg/revision/latest?cb=20140615151812",
                        HouseId = 3
                    },
                    new Founder()
                    {
                        Name = "Salazar Slytherin",
                        Gender = "male",
                        Species = "human",
                        Ancestry = "pure-blood",
                        ImageUrl = "https://static.wikia.nocookie.net/harrypotter/images/8/86/Salazar_Slytherin_WWHP.jpg/revision/latest?cb=20140615154545",
                        HouseId = 4
                    });
                }

                if (!context.Houses.Any())
                {
                    context.Houses.AddRange(houses);

                }

                if (!context.Characters.Any())
                {
                    context.Characters.AddRange(characters);
                }

                context.SaveChanges();


            };

        }

    }
}
