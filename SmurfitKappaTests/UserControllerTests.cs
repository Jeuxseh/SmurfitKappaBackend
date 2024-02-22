using Microsoft.AspNetCore.Mvc;
using Moq;
using SmarfitKappaBackend.Interfaces;
using SmarfitKappaBackend.Interfaces.SmurfitKappaBackend.Repositories;
using SmarfitKappaBackend.Models;
using SmurfitKappaBackend.Services;

namespace SmurfitKappaTests
{
    public class UserControllerTest
    {
        [Fact]
        public void GetAllUsers_ReturnsOkResultWithUsers()
        {
            var userServiceMock = new Mock<IUserService>();
            var controller = new UserController(userServiceMock.Object);

            var expectedUsers = new List<IUser>
            {
                new User {
                    UserId = 1,
                    FirstName = "Jesús",
                    LastName = "Ben",
                    Email = "mail@test.com"
                },
                new User {
                    UserId = 2,
                    FirstName = "Jes",
                    LastName = "Ele",
                    Email = "mail2@test.com"
                }
            };

            userServiceMock.Setup(service => service.GetAllUsers()).Returns(expectedUsers);

            var result = controller.Get() as OkObjectResult;

            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public void GetById_ValidUserId_ReturnsOkResultWithUser()
        {
            var userId = 1;
            var userServiceMock = new Mock<IUserService>();
            var controller = new UserController(userServiceMock.Object);

            var expectedUser = new User
            {
                UserId = 1,
                FirstName = "Jesús",
                LastName = "Ben",
                Email = "mail@test.com"
            };

            userServiceMock.Setup(service => service.GetUserById(userId)).Returns(expectedUser);

            var result = controller.GetById(userId) as OkObjectResult;

            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal(expectedUser, result.Value);
        }

        [Fact]
        public void GetById_InvalidUserId_ReturnsNotFoundResult()
        {
            var userId = 1;
            var userServiceMock = new Mock<IUserService>();
            var controller = new UserController(userServiceMock.Object);

            userServiceMock.Setup(service => service.GetUserById(userId)).Returns((IUser)null);

            var result = controller.GetById(userId) as NotFoundResult;

            Assert.NotNull(result);
            Assert.Equal(404, result.StatusCode);
        }

        [Fact]
        public void Create_ValidUser_ReturnsCreatedAtActionResult()
        {
            var userServiceMock = new Mock<IUserService>();
            var controller = new UserController(userServiceMock.Object);

            var newUser = new User
            {
                UserId = 1,
                FirstName = "Jesús",
                LastName = "Ben",
                Email = "mail@test.com"
            };

            var result = controller.Create(newUser) as CreatedAtActionResult;

            Assert.NotNull(result);
            Assert.Equal(201, result.StatusCode);
            Assert.Equal(nameof(controller.GetById), result.ActionName);
            Assert.Equal(newUser.UserId, result.RouteValues["id"]);
            Assert.Equal(newUser, result.Value);
        }

        [Fact]
        public void Update_InvalidUserId_ReturnsBadRequestResult()
        {
            var userId = 1;
            var userServiceMock = new Mock<IUserService>();
            var controller = new UserController(userServiceMock.Object);

            var invalidUser = new User
            {
                UserId = 2,
                FirstName = "Jesús",
                LastName = "Ben",
                Email = "mail@test.com"
            };

            var result = controller.Update(userId, invalidUser) as BadRequestResult;

            Assert.NotNull(result);
        }

        [Fact]
        public void Update_ValidUserId_ReturnsOkResult()
        {
            var userId = 1;
            var userServiceMock = new Mock<IUserService>();
            var controller = new UserController(userServiceMock.Object);

            var validUser = new User
            {
                UserId = 1,
                FirstName = "Jesús",
                LastName = "Ben",
                Email = "mail@test.com"
            };
      
            var result = controller.Update(userId, validUser) as OkObjectResult;
        
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public void Delete_ValidUserId_ReturnsNoContentResult()
        {
      
            var userId = 1;
            var userServiceMock = new Mock<IUserService>();
            var controller = new UserController(userServiceMock.Object);

            var result = controller.Delete(userId) as NoContentResult;

            Assert.NotNull(result);
            Assert.Equal(204, result.StatusCode);
        }

    }
}
