namespace API.Entities
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Species { get; set; }
        public string Ancestry { get; set; }
        public string ImageUrl { get; set; }
        public int HouseId { get; set; }
        public House House { get; set; }
    }
}