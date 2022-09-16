using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class HousesController : BaseApiController
    {
        private readonly DataContext _context;

        public HousesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<House>> GetHouseByName(string name)
        {
            return await _context.Houses.FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower());
        }
    }
}
