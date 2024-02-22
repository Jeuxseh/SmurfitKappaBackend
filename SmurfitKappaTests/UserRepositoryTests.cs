using Microsoft.EntityFrameworkCore;
using SmarfitKappaBackend.Models;
using SmurfitKappaBackend.Data;
using SmurfitKappaBackend.Repositories;
using Xunit;

public class UserRepositoryTests : IDisposable
{
    private readonly DbContextOptions<AppDbContext> _options;
    private readonly AppDbContext _context;

    public UserRepositoryTests()
    {
        _options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        _context = new AppDbContext(_options);
        SeedDatabase();
    }

    private void SeedDatabase()
    {
        var users = new List<User>
        {
            new User
            {
                UserId = 1,
                FirstName = "Jesús",
                LastName = "Ben",
                Email = "mail@test.com"
            },
            new User
            {
                UserId = 2,
                FirstName = "Jes",
                LastName = "Ele",
                Email = "mail2@test.com"
            }, 
            new User
            {
                UserId = 3,
                FirstName = "Jes",
                LastName = "Benele",
                Email = "mail3@test.com"
            }
    };

        _context.Users.AddRange(users);
        _context.SaveChanges();
    }

    [Fact]
    public void GetAllUsers_ReturnsCorrectUsers()
    {
        var repository = new UserRepository(_context);

        var users = repository.GetAllUsers();

        Assert.NotNull(users);
        Assert.Equal(3, users.Count());
    }

    [Fact]
    public void GetUserById_ValidUserId_ReturnsCorrectUser()
    {
        var repository = new UserRepository(_context);
        var userId = 1;

        var user = repository.GetUserById(userId);

        Assert.NotNull(user);
        Assert.Equal(userId, user.UserId);
    }

    [Fact]
    public void GetUserById_InvalidUserId_ReturnsNull()
    {
        var repository = new UserRepository(_context);
        var userId = 99;

        var user = repository.GetUserById(userId);

        Assert.Null(user);
    }

    [Fact]
    public void AddUser_AddsUserToDatabase()
    {
        var repository = new UserRepository(_context);
        var newUser = new User { UserId = 4, FirstName = "Bob", LastName = "Johnson", Email = "bob@example.com" };

        repository.AddUser(newUser);

        Assert.Equal(4, _context.Users.Count());
        Assert.Contains(_context.Users, u => u.UserId == 4);
    }

    [Fact]
    public void DeleteUser_DeletesUserFromDatabase()
    {
        var repository = new UserRepository(_context);
        var userIdToDelete = 1;

        repository.DeleteUser(userIdToDelete);

        Assert.Equal(2, _context.Users.Count());
        Assert.DoesNotContain(_context.Users, u => u.UserId == userIdToDelete);
    }

    public void Dispose()
    {
        _context.Database.EnsureDeleted();
        _context.Dispose();
    }
}
