using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class CharactersController : BaseApiController
    {
        private readonly DataContext _context;

        public CharactersController(DataContext context)
        {
            _context = context;
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<Character>>> GetCharacters()
        {
            return await _context.Characters.ToListAsync();
        }

        [HttpGet("house")]
        public async Task<ActionResult<IEnumerable<Character>>> GetCharactersByHouse(string name)
        {
            var house = await _context.Houses.FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower());

            if (house != null)
            {
                return await _context.Characters.Where(c => c.HouseId == house.Id).ToListAsync();
            }

            return NotFound("Items not found");
        }
    }
}
