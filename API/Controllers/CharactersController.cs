using Microsoft.AspNetCore.Mvc;
using SchoolPortalApi.Core.DTOs.CharacterDtos;
using SchoolPortalApi.Core.Interfaces.IRepositories;
using SchoolPortalAPI.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SchoolPortalAPI.Controllers
{
    public class CharactersController : BaseApiController
    {
        private readonly ICharacterRepository _characterRepository;

        public CharactersController(ICharacterRepository characterRepository)
        {
            _characterRepository = characterRepository;
        }

        // GET: api/characters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ViewCharacterDto>>> GetCharacters()
        {
            return Ok(await _characterRepository.GetAllAsync<ViewCharacterDto>());
        }

        // GET api/characters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ViewCharacterDto>> GetCharacter(int id)
        {
            var character = await _characterRepository.GetCharacterDetails(id);
            return character == null ? NotFound() : character;
        }

        // PUT api/characters/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Character>> UpdateCharacter(int id, [FromBody] UpdateCharacterDto characterDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bool isUpdated = await _characterRepository.UpdateAsync<UpdateCharacterDto>(id, characterDto);
            return isUpdated ? NoContent() : NotFound(id);

        }

        // POST api/characters
        [HttpPost]
        public async Task<ActionResult<Character>> CreateCharacter([FromBody] CreateCharacterDto characterDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _characterRepository.AddAsync<CreateCharacterDto, Character>(characterDto);

            return CreatedAtAction("CreatedNewCharacter", new { }, new { Name = characterDto.Name, Gender = characterDto.Gender });
        }

        // PUT api/characters/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Character>> DelteCharacter(int id)
        {
            bool isDelted = await _characterRepository.DeleteAsync(id);
            return isDelted ? NoContent(): NotFound(id);
        }
    }
}
