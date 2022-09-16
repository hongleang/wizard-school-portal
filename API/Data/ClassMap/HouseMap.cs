using API.Entities;
using CsvHelper.Configuration;

namespace API.Data.ClassMap
{
    public class HouseMap : ClassMap<House>
    {
        public HouseMap()
        {
            Map(m => m.Id).Name("id");
            Map(m => m.Name).Name("name");
            Map(m => m.Value).Name("value");
            Map(m => m.Motto).Name("motto");
            Map(m => m.LogoUrl).Name("logoUrl");
        }
    }
}
