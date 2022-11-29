using Microsoft.AspNetCore.Mvc;
using SchoolPortalApi.Core.DTOs.HouseDtos;
using SchoolPortalApi.Core.Interfaces.IRepositories;
using SchoolPortalAPI.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SchoolPortalAPI.Controllers
{
    public class HousesController : BaseApiController
    {
        private readonly IHouseRepository _houseRepository;

        public HousesController(IHouseRepository houseRepository)
        {
            _houseRepository = houseRepository;
        }

        // GET: api/houses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ViewHouseDto>>> GetHouses()
        {
            return Ok(await _houseRepository.GetAllAsync<ViewHouseDto>());
        }

        // GET api/houses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ViewHouseDto>> GetHouse(int? id)
        {            
            return await _houseRepository.GetAsync<ViewHouseDto>(id);
        }

        // PUT api/houses/5
        [HttpPut("{id}")]
        public async Task<ActionResult<House>> UpdateHouse(int id, [FromBody] UpdateHouseDto houseDto)
        {
            try
            {
                await _houseRepository.UpdateAsync<UpdateHouseDto>(id, houseDto);
                return NoContent();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}
