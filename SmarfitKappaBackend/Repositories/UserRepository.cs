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
            // Implementación para obtener todos los usuarios desde la base de datos
            return _context.Users.ToList();
        }

        public IUser GetUserById(int userId)
        {
            // Implementación para obtener un usuario por ID desde la base de datos
            return _context.Users.Find(userId);
        }

        public void AddUser(IUser user)
        {
            // Implementación para agregar un nuevo usuario a la base de datos
            _context.Users.Add((User)user);
            _context.SaveChanges();
        }

        public void UpdateUser(IUser user)
        {
            // Implementación para actualizar un usuario existente en la base de datos
            _context.Users.Update((User)user);
            _context.SaveChanges();
        }

        public void DeleteUser(int userId)
        {
            // Implementación para eliminar un usuario por ID de la base de datos
            var userToDelete = _context.Users.Find(userId);
            if (userToDelete != null)
            {
                _context.Users.Remove(userToDelete);
                _context.SaveChanges();
            }
        }
    }
}