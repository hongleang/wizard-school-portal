using API.Data.ClassMap;
using API.Entities;
using CsvHelper;
using CsvHelper.Configuration;
using Newtonsoft.Json.Linq;
using System.Diagnostics.Metrics;

namespace API.Data
{
    public class DataProcessor
    {
        public List<House> Houses { get; private set; }
        public List<Character> Characters { get; private set; } = new List<Character>();
        private string Path { get; set; }
        private CsvConfiguration Config { get; set; }
        private string RecordType { get; set; }

        public DataProcessor(string path, CsvConfiguration config, string type)
        {
            Path = path;
            Config = config;
            RecordType = type;
            Houses = new List<House>();

            CsvProcessor();
        }

        public DataProcessor(string path, CsvConfiguration config, List<House> houses)
        {
            Path = path;
            Config = config;
            RecordType = "characters";
            Houses = houses;
            CsvProcessor();
        }

        private void CsvProcessor()
        {
            using var streamReader = File.OpenText(Path);
            using (var csvReader = new CsvReader(streamReader, Config))
            {
                csvReader.Read();
                csvReader.ReadHeader();
                int i = 0;
                dynamic record;

                while (csvReader.Read())
                {
                    if (RecordType == "house")
                    {
                        csvReader.Context.RegisterClassMap<HouseMap>();
                        record = csvReader.GetRecord<House>();
                        Houses.Add(new House()
                        {
                            Id = record.Id,
                            Name = record.Name,
                            Value = record.Value,
                            Motto = record.Motto,
                            LogoUrl = record.LogoUrl,
                            FounderId = i + 1
                        });
                    }
                    else
                    {
                        csvReader.Context.RegisterClassMap<CharacterMap>();
                        record = csvReader.GetRecord<Character>();

                        var name = csvReader.GetField<string>("house");
                        Characters.Add(new Character()
                        {
                            Id = record.Id,
                            Name = record.Name,
                            Gender = record.Gender,
                            Species = record.Species,
                            ImageUrl = record.ImageUrl,
                            Ancestry = record.Ancestry,
                            House = Houses.Find(x => x.Name == csvReader.GetField<string>("house"))
                        });
                    }
                    i++;
                }
            }
        }
    }
}
