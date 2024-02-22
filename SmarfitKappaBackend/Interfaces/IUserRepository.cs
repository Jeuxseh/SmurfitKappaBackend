namespace SmarfitKappaBackend.Interfaces
{
    namespace SmurfitKappaBackend.Repositories
    {
        public interface IUserRepository
        {
            IEnumerable<IUser> GetAllUsers();
            IUser GetUserById(int userId);
            void AddUser(IUser user);
            void UpdateUser(IUser user);
            void DeleteUser(int userId);
        }
    }
}
