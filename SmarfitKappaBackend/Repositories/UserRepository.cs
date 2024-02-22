using Microsoft.EntityFrameworkCore;
using SmarfitKappaBackend.Interfaces;
using SmarfitKappaBackend.Interfaces.SmurfitKappaBackend.Repositories;
using SmarfitKappaBackend.Models;
using SmurfitKappaBackend.Data;

namespace SmurfitKappaBackend.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<IUser> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public IUser GetUserById(int userId)
        {
            return _context.Users.Find(userId);
        }

        public void AddUser(IUser user)
        {
            _context.Users.Add((User)user);
            _context.SaveChanges();
        }

        public void UpdateUser(IUser user)
        {
            _context.Users.Update((User)user);
            _context.SaveChanges();
        }

        public void DeleteUser(int userId)
        {
            var userToDelete = _context.Users.Find(userId);
            if (userToDelete != null)
            {
                _context.Users.Remove(userToDelete);
                _context.SaveChanges();
            }
        }
    }
}