using API.Entities;
using CsvHelper.Configuration;

namespace API.Data.ClassMap
{
    public class CharacterMap : ClassMap<Character>
    {
        public CharacterMap()
        {
            Map(m => m.Id).Name("id");
            Map(m => m.Name).Name("name");
            Map(m => m.Gender).Name("gender");
            Map(m => m.Species).Name("species");
            Map(m => m.Ancestry).Name("ancestry");
            Map(m => m.ImageUrl).Name("imageUrl");
        }
    }
}
