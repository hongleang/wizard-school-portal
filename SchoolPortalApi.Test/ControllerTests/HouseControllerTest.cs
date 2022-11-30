using Microsoft.AspNetCore.Mvc;
using Moq;
using SchoolPortalAPI.Controllers;
using SchoolPortalApi.Core.Interfaces.IRepositories;
using SchoolPortalAPI.Entities;
using System.Net;
using SchoolPortalApi.Test.Mocks;
using SchoolPortalApi.Core.DTOs.HouseDtos;

namespace SchoolPortalApi.Test.ControllerTests
{
    public class HouseControllerTest
    {
        private readonly Mock<IHouseRepository> _mockRepo;
        private readonly HousesController _controller;
        private readonly IEnumerable<ViewHouseDto> _houses;

        public HouseControllerTest()
        {
            _mockRepo = new Mock<IHouseRepository>();
            _controller = new HousesController(_mockRepo.Object);
            _houses = new MockResource().ListOfHouses;
        }

        // Test GetHouses() method
        [Fact]
        public async Task GetHouse_ReturnsOkObjectResult_WithIEnumerableOfViewHouseDto()
        {
            // Arrange
            _mockRepo.Setup(repo => repo.GetAllAsync<ViewHouseDto>())
                .ReturnsAsync(_houses);

            // Action
            var result = await _controller.GetHouses();

            // Assert
            var actionResult = Assert.IsAssignableFrom<OkObjectResult>(result.Result); // Should result Ok() response
            var model = Assert.IsAssignableFrom<IEnumerable<ViewHouseDto>>(
                actionResult.Value);
            Assert.Equal(2, model.Count());
        }

        // Test GetHouse(int id) method
        [Fact]
        public async Task GetHouse_ReturnsViewHouseDto()
        {
            // Arrange
            int id = 1;
            _mockRepo.Setup(repo => repo.GetAsync<ViewHouseDto>(id))
                .ReturnsAsync(FindHouse(id));

            // Action
            var result = await _controller.GetHouse(id);

            // Assert
            var response = Assert.IsType<ActionResult<ViewHouseDto>>(result);
            var model = Assert.IsAssignableFrom<ViewHouseDto>(response.Value);
            Assert.Equal(id, model.Id);
        }

        [Fact]
        public async Task GetHouse_ReturnsNotFoundResultWith404StatusCode()
        {
            // Arrange
            int invalidId = 25;
            _mockRepo.Setup(repo => repo.GetAsync<ViewHouseDto>(invalidId))
                .ReturnsAsync(FindHouse(invalidId));

            // Action
            var result = await _controller.GetHouse(invalidId);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result.Result);
            Assert.Equal((int)HttpStatusCode.NotFound, notFoundResult.StatusCode);
            Assert.Equal(invalidId, notFoundResult.Value);
        }

        // Test UpdateHouse(int id, [FromBody] UpdateHouseDto houseDto) method
        [Fact]
        public async Task UpdateHouse_WhenModelIsValidReturnNoContentResultWith204StatusCode()
        {
            var id = 1;
            var newHouseDto = MapHouseEntity(id);

            _mockRepo.Setup(repo => repo.UpdateAsync<UpdateHouseDto>(id, newHouseDto))
                .Returns(Task.FromResult(newHouseDto != null));

            var result = await _controller.UpdateHouse(id, newHouseDto);

            var actionResult = Assert.IsAssignableFrom<ActionResult<House>>(result);
            var noContentResult = Assert.IsAssignableFrom<NoContentResult>(result.Result);
            Assert.Equal((int)HttpStatusCode.NoContent, noContentResult.StatusCode);
        }

        [Fact]
        public async Task UpdateHouse_WhenNotFoundReturnNotFoundResultWith404StatusCode()
        {
            var id = 20;
            var newHouseDto = MapHouseEntity(id);
            _mockRepo.Setup(repo => repo.UpdateAsync<UpdateHouseDto>(id, newHouseDto))
                .Returns(Task.FromResult(newHouseDto != null));

            var result = await _controller.UpdateHouse(id, newHouseDto);

            var actionResult = Assert.IsAssignableFrom<ActionResult<House>>(result);
            var notFoundResult = Assert.IsAssignableFrom<NotFoundObjectResult>(result.Result);
            Assert.Equal((int)HttpStatusCode.NotFound, notFoundResult.StatusCode);
            Assert.Equal(id, notFoundResult.Value);
        }

        [Fact]
        public async Task UpdateHouse_WhenModelIsNotValidReturnBadRequestWith400StatusCode()
        {
            var id = 1;
            _mockRepo.Setup(repo => repo.UpdateAsync<UpdateHouseDto>(id, null))
                .Returns(Task.FromResult(false));

            _controller.ModelState.AddModelError("error", "some validation error");
            var result = await _controller.UpdateHouse(id, null);

            var actionResult = Assert.IsAssignableFrom<ActionResult<House>>(result);
            var badRequestResult = Assert.IsAssignableFrom<BadRequestObjectResult>(result.Result);
            Assert.Equal((int)HttpStatusCode.BadRequest, badRequestResult.StatusCode);
        }

        private ViewHouseDto? FindHouse(int id)
        {
            return _houses.FirstOrDefault(x => x.Id == id);
        }

        private UpdateHouseDto? MapHouseEntity(int id)
        {
            var house = FindHouse(id);
            if (house != null)
            {
                return new UpdateHouseDto()
                {
                    Id = id,
                    Name = house.Name,
                    LogoUrl = house.LogoUrl,
                    Motto = house.Motto,
                    Value = house.Value
                };
            }
            return null;
        }
    }
}

