using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolPortalAPI.Entities;

public class House
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Value { get; set; }
    public string Motto { get; set; }
    public string LogoUrl { get; set; }
    public int FounderId { get; set; }
    public Founder Founder { get; set; }
    public ICollection<Character> Characters { get; set; }
}