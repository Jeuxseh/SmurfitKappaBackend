using SmarfitKappaBackend.Interfaces;
using SmarfitKappaBackend.Interfaces.SmurfitKappaBackend.Repositories;


namespace SmurfitKappaBackend.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IEnumerable<IUser> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }

        public IUser GetUserById(int userId)
        {
            return _userRepository.GetUserById(userId);
        }

        public void AddUser(IUser user)
        {
            _userRepository.AddUser(user);
        }

        public void UpdateUser(IUser user)
        {
            _userRepository.UpdateUser(user);
        }

        public void DeleteUser(int userId)
        {
            _userRepository.DeleteUser(userId);
        }
    }
}