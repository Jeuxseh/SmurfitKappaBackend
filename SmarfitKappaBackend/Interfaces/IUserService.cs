namespace SmarfitKappaBackend.Interfaces
{
    
    public interface IUserService
    {
        IEnumerable<IUser> GetAllUsers();
        IUser GetUserById(int userId);
        void AddUser(IUser user);
        void UpdateUser(IUser user);
        void DeleteUser(int userId);
    }
    
}
