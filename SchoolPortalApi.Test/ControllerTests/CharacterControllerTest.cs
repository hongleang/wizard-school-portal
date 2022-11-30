using Microsoft.AspNetCore.Mvc;
using Moq;
using SchoolPortalApi.Core.DTOs.CharacterDtos;
using SchoolPortalApi.Core.Interfaces.IRepositories;
using SchoolPortalApi.Test.Mocks;
using SchoolPortalAPI.Controllers;
using SchoolPortalAPI.Entities;
using System.Net;

namespace SchoolPortalApi.Test.ControllerTests
{
    public class CharacterControllerTest
    {
        private readonly Mock<ICharacterRepository> _mockRepo;
        private readonly CharactersController _controller;
        private readonly IEnumerable<ViewCharacterDto> _characters;

        public CharacterControllerTest()
        {
            _mockRepo = new Mock<ICharacterRepository>();
            _controller = new CharactersController(_mockRepo.Object);
            _characters = new MockResource().ListOfCharacters;
        }

        // Test GetCharacters() method
        [Fact]
        public async Task GetCharacter_ReturnsOkObjectResult_WithIEnumerableOfViewCharacterDto()
        {
            // Arrange
            _mockRepo.Setup(repo => repo.GetAllAsync<ViewCharacterDto>())
                .ReturnsAsync(_characters);

            // Action
            var result = await _controller.GetCharacters();

            // Assert
            var actionResult = Assert.IsAssignableFrom<OkObjectResult>(result.Result); // Should result Ok() response
            var model = Assert.IsAssignableFrom<IEnumerable<ViewCharacterDto>>(
                actionResult.Value);
            Assert.Equal(2, model.Count());
        }

        // Test GetCharacter(int id) method
        [Fact]
        public async Task GetCharacter_ReturnsViewCharacterDto()
        {
            // Arrange
            int id = 1;
            _mockRepo.Setup(repo => repo.GetCharacterDetails(id))
                .ReturnsAsync(FindCharacter(id));

            // Action
            var result = await _controller.GetCharacter(id);

            // Assert
            var response = Assert.IsType<ActionResult<ViewCharacterDto>>(result);
            var model = Assert.IsAssignableFrom<ViewCharacterDto>(response.Value);
            Assert.Equal(id, model.Id);
        }

        [Fact]
        public async Task GetCharacter_ReturnsNotFoundResultWith404StatusCode()
        {
            // Arrange
            int invalidId = 25;
            _mockRepo.Setup(repo => repo.GetCharacterDetails(invalidId))
                .ReturnsAsync(FindCharacter(invalidId));

            // Action
            var result = await _controller.GetCharacter(invalidId);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundResult>(result.Result);
            Assert.Equal((int)HttpStatusCode.NotFound, notFoundResult.StatusCode);
        }

        // Test CreateCharacter([FromBody] CreateCharacterDto characterDto) method
        [Fact]
        public async Task CreateCharacter_WhenModelIsValidReturnsCreateAtActionResultWith201StatusCode()
        {
            var newCharacterDto = MapCreateCharacterEntity(1);

            _mockRepo.Setup(repo => repo.AddAsync<CreateCharacterDto, Character>(newCharacterDto))
                .Returns(Task.FromResult(true));

            var result = await _controller.CreateCharacter(newCharacterDto);

            var actionResult = Assert.IsAssignableFrom<ActionResult<Character>>(result);
            var createdAtaction = Assert.IsAssignableFrom<CreatedAtActionResult>(actionResult.Result);
            Assert.Equal((int)HttpStatusCode.Created, createdAtaction.StatusCode);
        }

        [Fact]
        public async Task CreateCharacter_WhenModelIsNotValidReturnsBadRequestWith400StatusCode()
        {
            _controller.ModelState.AddModelError("error", "some error");
            var result = await _controller.CreateCharacter(MapCreateCharacterEntity(5));

            var actionResult = Assert.IsAssignableFrom<ActionResult<Character>>(result);
            var badRequestResult = Assert.IsAssignableFrom<BadRequestObjectResult>(actionResult.Result);
            Assert.Equal((int)HttpStatusCode.BadRequest, badRequestResult.StatusCode);
            Assert.IsAssignableFrom<SerializableError>(badRequestResult.Value);

        }

        // Test UpdateCharacter(int id, [FromBody] UpdateCharacterDto characterDto) method
        [Fact]
        public async Task UpdateCharacter_WhenModelIsValidReturnNoContentResultWith204StatusCode()
        {
            var id = 1;
            var newCharacterDto = MapCharacterEntity(id);

            _mockRepo.Setup(repo => repo.UpdateAsync<UpdateCharacterDto>(id, newCharacterDto))
                .Returns(Task.FromResult(newCharacterDto != null));

            var result = await _controller.UpdateCharacter(id, newCharacterDto);

            var actionResult = Assert.IsAssignableFrom<ActionResult<Character>>(result);
            var noContentResult = Assert.IsAssignableFrom<NoContentResult>(result.Result);
            Assert.Equal((int)HttpStatusCode.NoContent, noContentResult.StatusCode);
        }

        [Fact]
        public async Task UpdateCharacter_WhenNotFoundReturnNotFoundResultWith404StatusCode()
        {
            var id = 20;
            var newCharacterDto = MapCharacterEntity(id);
            _mockRepo.Setup(repo => repo.UpdateAsync<UpdateCharacterDto>(id, newCharacterDto))
                .Returns(Task.FromResult(newCharacterDto != null));

            var result = await _controller.UpdateCharacter(id, newCharacterDto);

            var actionResult = Assert.IsAssignableFrom<ActionResult<Character>>(result);
            var notFoundResult = Assert.IsAssignableFrom<NotFoundObjectResult>(result.Result);
            Assert.Equal((int)HttpStatusCode.NotFound, notFoundResult.StatusCode);
            Assert.Equal(id, notFoundResult.Value);
        }

        [Fact]
        public async Task UpdateCharacter_WhenModelIsNotValidReturnBadRequestWith400StatusCode()
        {
            var id = 1;
            _mockRepo.Setup(repo => repo.UpdateAsync<UpdateCharacterDto>(id, null))
                .Returns(Task.FromResult(false));

            _controller.ModelState.AddModelError("error", "some validation error");
            var result = await _controller.UpdateCharacter(id, null);

            var actionResult = Assert.IsAssignableFrom<ActionResult<Character>>(result);
            var badRequestResult = Assert.IsAssignableFrom<BadRequestObjectResult>(result.Result);
            Assert.Equal((int)HttpStatusCode.BadRequest, badRequestResult.StatusCode);
        }


        // Test DelteCharacter(int id) method
        [Fact]
        public async Task DelteCharacter_WhenFoundReturnNoContent()
        {
            int id = 1;
            var entity = FindCharacter(id);
            _mockRepo.Setup(repo => repo.DeleteAsync(id))
                .Returns(Task.FromResult(entity != null));

            var result = await _controller.DelteCharacter(id);

            var actionResult = Assert.IsAssignableFrom<ActionResult<Character>>(result);
            var noContentResult = Assert.IsAssignableFrom<NoContentResult>(actionResult.Result);
            Assert.Equal((int)HttpStatusCode.NoContent, noContentResult.StatusCode);
        }

        [Fact]
        public async Task DelteCharacter_WhenNotFoundReturnNotFoundWith404StatusCode()
        {
            int id = 4;
            var entity = FindCharacter(id);
            _mockRepo.Setup(repo => repo.DeleteAsync(id))
                .Returns(Task.FromResult(entity != null));

            var result = await _controller.DelteCharacter(id);

            var actionResult = Assert.IsAssignableFrom<ActionResult<Character>>(result);
            var notFoundResult = Assert.IsAssignableFrom<NotFoundObjectResult>(actionResult.Result);
            Assert.Equal((int)HttpStatusCode.NotFound, notFoundResult.StatusCode);
            Assert.Equal(id, notFoundResult.Value);
        }

        private ViewCharacterDto? FindCharacter(int id)
        {
            return _characters.FirstOrDefault(x => x.Id == id);
        }

        private UpdateCharacterDto? MapCharacterEntity(int id)
        {
            var character = FindCharacter(id);
            if (character != null)
            {
                return new UpdateCharacterDto()
                {
                    Id = id,
                    Gender = character.Gender,
                    HouseId = 2,
                    Name = character.Name,
                    ImageUrl = character.ImageUrl
                };
            }
            return null;
        }

        private CreateCharacterDto? MapCreateCharacterEntity(int id)
        {
            var character = FindCharacter(id);
            if (character != null)
            {
                return new CreateCharacterDto()
                {
                    Id = _characters.Count() + 1,
                    Gender = character.Gender,
                    HouseId = 2,
                    Name = character.Name,
                    ImageUrl = character.ImageUrl
                };
            }
            return null;
        }

    }
}