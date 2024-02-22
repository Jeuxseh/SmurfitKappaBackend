using Moq;
using SmarfitKappaBackend.Interfaces;
using SmarfitKappaBackend.Interfaces.SmurfitKappaBackend.Repositories;
using SmarfitKappaBackend.Models;
using SmurfitKappaBackend.Services;

namespace SmurfitKappaTests
{
    public class UserServiceTests
    {
        [Fact]
        public void GetAllUsers_ReturnsAllUsers()
        {

            var userRepositoryMock = new Mock<IUserRepository>();
            var userService = new UserService(userRepositoryMock.Object);

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

            userRepositoryMock.Setup(repo => repo.GetAllUsers()).Returns(expectedUsers);

  
            var actualUsers = userService.GetAllUsers();


            Assert.Equal(expectedUsers, actualUsers);
        }

        [Fact]
        public void GetUserById_ReturnsCorrectUser()
        {

            var userId = 1;
            var userRepositoryMock = new Mock<IUserRepository>();
            var userService = new UserService(userRepositoryMock.Object);

            var expectedUser = new User
            {
                UserId = 1,
                FirstName = "Jesús",
                LastName = "Ben",
                Email = "mail@test.com"
            };

            userRepositoryMock.Setup(repo => repo.GetUserById(userId)).Returns(expectedUser);

     
            var actualUser = userService.GetUserById(userId);


            Assert.Equal(expectedUser, actualUser);
        }

        [Fact]
        public void AddUser_CallsRepositoryAddUser()
        {
    
            var userRepositoryMock = new Mock<IUserRepository>();
            var userService = new UserService(userRepositoryMock.Object);

            var newUser = new User
            {
                UserId = 1,
                FirstName = "Jesús",
                LastName = "Ben",
                Email = "mail@test.com"
            };


            userService.AddUser(newUser);


            userRepositoryMock.Verify(repo => repo.AddUser(newUser), Times.Once);
        }

        [Fact]
        public void UpdateUser_CallsRepositoryUpdateUser()
        {

            var userRepositoryMock = new Mock<IUserRepository>();
            var userService = new UserService(userRepositoryMock.Object);

            var updatedUser = new User
            {
                UserId = 1,
                FirstName = "Jesús",
                LastName = "Ben",
                Email = "mail@test.com"
            };

            userService.UpdateUser(updatedUser);

            userRepositoryMock.Verify(repo => repo.UpdateUser(updatedUser), Times.Once);
        }

        [Fact]
        public void DeleteUser_CallsRepositoryDeleteUser()
        {

            var userId = 1;
            var userRepositoryMock = new Mock<IUserRepository>();
            var userService = new UserService(userRepositoryMock.Object);


            userService.DeleteUser(userId);


            userRepositoryMock.Verify(repo => repo.DeleteUser(userId), Times.Once);
        }

    }
}
